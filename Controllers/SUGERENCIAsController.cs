using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOF_S_MA_7_1_TAREA_Back_End_Front_End_API.Models;
using Microsoft.AspNetCore.Authorization;
using SOF_S_MA_7_1_TAREA_Back_End_Front_End_API.Data;

namespace SOF_S_MA_7_1_TAREA_Back_End_Front_End_API.Controllers
{
    [Route("api/[controller]")]

    [Authorize]
    [ApiController]
    
    public class SUGERENCIAsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SUGERENCIAsController(ApplicationDbContext context)
        {
            _context = context;
            _context.SUGERENCIA.ToList();
        }

        // GET: api/SUGERENCIAs
        
        

        // DELETE: api/SUGERENCIAs/5
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<SUGERENCIA>>> GetSugerencia()
        {
            IQueryable<SUGERENCIA> qlibro = _context.SUGERENCIA;
            if (qlibro == null)
            {
                return NotFound();
            }
            return await qlibro.ToListAsync();
        }

        private bool SUGERENCIAExists(int id)
        {
            return (_context.SUGERENCIA?.Any(e => e.id_sugerencia == id)).GetValueOrDefault();
        }
    }
}
