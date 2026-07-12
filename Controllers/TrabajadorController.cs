using ConcesionariaQuiros.Data;
using ConcesionariaQuiros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcesionariaQuiros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadoresController : ControllerBase
    {
        private readonly ConcesionariaContext _context;

        // Inyección del DbContext
        public TrabajadoresController(ConcesionariaContext context)
        {
            _context = context;
        }

        // GET: api/Trabajadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trabajador>>> GetTrabajadores()
        {
            return await _context.Trabajadores.ToListAsync();
        }

        // GET: api/Trabajadores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trabajador>> GetTrabajador(int id)
        {
            var trabajador = await _context.Trabajadores.FindAsync(id);

            if (trabajador == null)
                return NotFound();

            return trabajador;
        }

        // POST: api/Trabajadores
        [HttpPost]
        public async Task<ActionResult<Trabajador>> PostTrabajador(Trabajador trabajador)
        {
            _context.Trabajadores.Add(trabajador);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetTrabajador),
                new { id = trabajador.TrabajadorId },
                trabajador
            );
        }

        // PUT: api/Trabajadores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrabajador(int id, Trabajador trabajador)
        {
            if (id != trabajador.TrabajadorId)
                return BadRequest();

            _context.Entry(trabajador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Trabajadores.Any(e => e.TrabajadorId == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Trabajadores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrabajador(int id)
        {
            var trabajador = await _context.Trabajadores.FindAsync(id);

            if (trabajador == null)
                return NotFound();

            _context.Trabajadores.Remove(trabajador);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
