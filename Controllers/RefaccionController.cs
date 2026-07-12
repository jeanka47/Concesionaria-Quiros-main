using ConcesionariaQuiros.Data;
using ConcesionariaQuiros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcesionariaQuiros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefaccionesController : ControllerBase
    {
        private readonly ConcesionariaContext _context;

        // Inyección del DbContext
        public RefaccionesController(ConcesionariaContext context)
        {
            _context = context;
        }

        // GET: api/Refacciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Refaccion>>> GetRefacciones()
        {
            return await _context.Refacciones.ToListAsync();
        }

        // GET: api/Refacciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Refaccion>> GetRefaccion(int id)
        {
            var refaccion = await _context.Refacciones.FindAsync(id);

            if (refaccion == null)
                return NotFound();

            return refaccion;
        }

        // POST: api/Refacciones
        [HttpPost]
        public async Task<ActionResult<Refaccion>> PostRefaccion(Refaccion refaccion)
        {
            _context.Refacciones.Add(refaccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetRefaccion),
                new { id = refaccion.RefaccionId },
                refaccion
            );
        }

        // PUT: api/Refacciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRefaccion(int id, Refaccion refaccion)
        {
            if (id != refaccion.RefaccionId)
                return BadRequest();

            _context.Entry(refaccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Refacciones.Any(e => e.RefaccionId == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Refacciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRefaccion(int id)
        {
            var refaccion = await _context.Refacciones.FindAsync(id);

            if (refaccion == null)
                return NotFound();

            _context.Refacciones.Remove(refaccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
