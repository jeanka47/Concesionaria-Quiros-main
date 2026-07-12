using ConcesionariaQuiros.Data;
using ConcesionariaQuiros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcesionariaQuiros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReparacionesController : ControllerBase
    {
        private readonly ConcesionariaContext _context;

        // Inyección del DbContext
        public ReparacionesController(ConcesionariaContext context)
        {
            _context = context;
        }

        // GET: api/Reparaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reparacion>>> GetReparaciones()
        {
            return await _context.Reparaciones.ToListAsync();
        }

        // GET: api/Reparaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reparacion>> GetReparacion(int id)
        {
            var reparacion = await _context.Reparaciones.FindAsync(id);

            if (reparacion == null)
                return NotFound();

            return reparacion;
        }

        // POST: api/Reparaciones
        [HttpPost]
        public async Task<ActionResult<Reparacion>> PostReparacion(Reparacion reparacion)
        {
            _context.Reparaciones.Add(reparacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetReparacion),
                new { id = reparacion.ReparacionId },
                reparacion
            );
        }

        // PUT: api/Reparaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReparacion(int id, Reparacion reparacion)
        {
            if (id != reparacion.ReparacionId)
                return BadRequest();

            _context.Entry(reparacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Reparaciones.Any(e => e.ReparacionId == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Reparaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReparacion(int id)
        {
            var reparacion = await _context.Reparaciones.FindAsync(id);

            if (reparacion == null)
                return NotFound();

            _context.Reparaciones.Remove(reparacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
