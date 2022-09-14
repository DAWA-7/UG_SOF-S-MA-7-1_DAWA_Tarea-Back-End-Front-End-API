using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOF_S_MA_7_1_TAREA_Back_End_Front_End_API.Data;
using SOF_S_MA_7_1_TAREA_Back_End_Front_End_API.Models.Catalog;

namespace SOF_S_MA_7_1_TAREA_Back_End_Front_End_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Libros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibro()
        {
            IQueryable<Libro> qlibro = _context.Libro.Include(e => e.Editorial).Include(e => e.Imagen).Include(e => e.Categoria).Include(e => e.Autor);

            if (qlibro == null)
          {
              return NotFound();
          }
            return await qlibro.ToListAsync();
        }

        // GET: api/Libros
        [HttpGet("/GetCategorias")]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoria()
        {
            IQueryable<Categoria> qcateg = _context.Categoria;

            if (qcateg == null)
            {
                return NotFound();
            }
            return await qcateg.ToListAsync();
        }

        // GET: api/categorias
        [HttpGet("{categoria}/buscarCategoria")]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetLibroCategoria(string categoria)
        {
            IQueryable<CategoriaLibro> categorias = _context.CategoriaLibro;
            IQueryable<Libro> qlibro = _context.Libro;
            IQueryable<Categoria> qcateg = _context.Categoria;
            categorias = categorias.Where(e => e.Categoria.NombreCategoria.Contains(categoria));
            //var id = (from idc in qcateg where idc.NombreCategoria == categoria select idc).First().IdCategoria;
            //qcateg = qcateg.Where(e => e.IdCategoria == id).Include(e => e.CategoriaLibro);
            if (qcateg == null)
            {
                return NotFound();
            }
            return await qcateg.ToListAsync();
        }

        // GET: api/Libros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> GetLibro(int id)
        {
          if (_context.Libro == null)
          {
              return NotFound();
          }
            var libro = await _context.Libro.FindAsync(id);

            if (libro == null)
            {
                return NotFound();
            }

            return libro;
        }

        // PUT: api/Libros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro(int id, Libro libro)
        {
            if (id != libro.IdLibro)
            {
                return BadRequest();
            }

            _context.Entry(libro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExists(id))
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

        // POST: api/Libros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Libro>> PostLibro(Libro libro)
        {
          if (_context.Libro == null)
          {
              return Problem("Entity set 'ApplicationDBContext.Libro'  is null.");
          }
            _context.Libro.Add(libro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibro", new { id = libro.IdLibro }, libro);
        }

        // DELETE: api/Libros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro(int id)
        {
            if (_context.Libro == null)
            {
                return NotFound();
            }
            var libro = await _context.Libro.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            _context.Libro.Remove(libro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibroExists(int id)
        {
            return (_context.Libro?.Any(e => e.IdLibro == id)).GetValueOrDefault();
        }
    }
}
