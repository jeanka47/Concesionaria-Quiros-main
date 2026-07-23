using ConcesionariaQuiros.Data;
using ConcesionariaQuiros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcesionariaQuiros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcesionariosController : ControllerBase
    {
        private readonly ConcesionariaContext _context;

        // Inyección del DbContext
        public ConcesionariosController(ConcesionariaContext context)
        {
            _context = context;
        }

        // 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Concesionario>>> GetConcesionarios()
        {
            return await _context.Concesionarios.ToListAsync();
        }

        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<Concesionario>> GetConcesionario(int id)
        {
            var concesionario = await _context.Concesionarios.FindAsync(id);

            if (concesionario == null)
                return NotFound();

            return concesionario;
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<Concesionario>> PostConcesionario(Concesionario concesionario)
        {
            _context.Concesionarios.Add(concesionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetConcesionario),
                new { id = concesionario.ConcesionarioId },
                concesionario
            );
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConcesionario(int id, Concesionario concesionario)
        {
            if (id != concesionario.ConcesionarioId)
                return BadRequest();

            _context.Entry(concesionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Concesionarios.Any(e => e.ConcesionarioId == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConcesionario(int id)
        {
            var concesionario = await _context.Concesionarios.FindAsync(id);

            if (concesionario == null)
                return NotFound();

            _context.Concesionarios.Remove(concesionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
