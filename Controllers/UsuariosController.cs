using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SOF_S_MA_7_1_TAREA_Back_End_Front_End_API.Data;
using SOF_S_MA_7_1_TAREA_Back_End_Front_End_API.Models;

namespace SOF_S_MA_7_1_TAREA_Back_End_Front_End_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public UsuariosController(ApplicationDbContext context,  IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost("Login")]
    public async Task<ActionResult> PostCliente(Login login)
    {
        var userTemp = await _context.Usuario.FirstOrDefaultAsync
            (x => x.USERNAME.ToLower().Equals(login.USERNAME));
        if (userTemp == null){ 
            return BadRequest("UserNotFound"); 
        }
        else if (userTemp.PASSWORD.Equals(login.PASSWORD))   {
            //return Ok("UserFound");
            return Ok(JsonConvert.SerializeObject(CrearToken(userTemp)));
        }
        else{
            return BadRequest("keyError");
        }         
    }
    
    private string CrearToken(Usuarios user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.USUARIOID.ToString()),
            new Claim(ClaimTypes.Name, user.USERNAME),
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
            GetBytes(_configuration.GetSection("AppSettings:Token").Value));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = System.DateTime.Now.AddDays(1),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);

    }
}