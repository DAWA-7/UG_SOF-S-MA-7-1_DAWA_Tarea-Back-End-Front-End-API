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
            _context.AUTOR_SUGERENCIA.ToList();
            _context.AUTOR_SUGERENCIA_SUGERENCIA.ToList();
            _context.ESTADO.ToList();
            _context.SUGERENCIA.ToList();
            _context.USUARIO.ToList();
        }

        // GET: api/SUGERENCIAs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SUGERENCIA>>> GetSUGERENCIA()
        {
          if (_context.SUGERENCIA == null)
          {
              return NotFound();
          }
            return await _context.SUGERENCIA.ToListAsync();
        }

        // GET: api/SUGERENCIAs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SUGERENCIA>> GetSUGERENCIA(int id)
        {
          if (_context.SUGERENCIA == null)
          {
              return NotFound();
          }
            var sUGERENCIA = await _context.SUGERENCIA.FindAsync(id);

            if (sUGERENCIA == null)
            {
                return NotFound();
            }

            return sUGERENCIA;
        }

        // PUT: api/SUGERENCIAs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSUGERENCIA(int id, SUGERENCIA sUGERENCIA)
        {
            if (id != sUGERENCIA.SUGERENCIAID)
            {
                return BadRequest();
            }

            _context.Entry(sUGERENCIA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SUGERENCIAExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SUGERENCIAs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SUGERENCIA>> PostSUGERENCIA(SUGERENCIA sUGERENCIA)
        {
          if (_context.SUGERENCIA == null)
          {
              return Problem("Entity set 'ApplicationDbContext.SUGERENCIA'  is null.");
          }
            _context.SUGERENCIA.Add(sUGERENCIA);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSUGERENCIA", new { id = sUGERENCIA.SUGERENCIAID }, sUGERENCIA);
        }

        // DELETE: api/SUGERENCIAs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSUGERENCIA(int id)
        {
            if (_context.SUGERENCIA == null)
            {
                return NotFound();
            }
            var sUGERENCIA = await _context.SUGERENCIA.FindAsync(id);
            if (sUGERENCIA == null)
            {
                return NotFound();
            }

            _context.SUGERENCIA.Remove(sUGERENCIA);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SUGERENCIAExists(int id)
        {
            return (_context.SUGERENCIA?.Any(e => e.SUGERENCIAID == id)).GetValueOrDefault();
        }
    }
}
