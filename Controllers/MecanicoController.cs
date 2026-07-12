using ConcesionariaQuiros.Data;
using ConcesionariaQuiros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcesionariaQuiros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MecanicosController : ControllerBase
    {
        private readonly ConcesionariaContext _context;

        // Inyección del DbContext
        public MecanicosController(ConcesionariaContext context)
        {
            _context = context;
        }

        // GET: api/Mecanicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mecanico>>> GetMecanicos()
        {
            return await _context.Mecanicos.ToListAsync();
        }

        // GET: api/Mecanicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mecanico>> GetMecanico(int id)
        {
            var mecanico = await _context.Mecanicos.FindAsync(id);

            if (mecanico == null)
                return NotFound();

            return mecanico;
        }

        // POST: api/Mecanicos
        [HttpPost]
        public async Task<ActionResult<Mecanico>> PostMecanico(Mecanico mecanico)
        {
            _context.Mecanicos.Add(mecanico);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetMecanico),
                new { id = mecanico.MecanicoId },
                mecanico
            );
        }

        // PUT: api/Mecanicos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMecanico(int id, Mecanico mecanico)
        {
            if (id != mecanico.MecanicoId)
                return BadRequest();

            _context.Entry(mecanico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Mecanicos.Any(e => e.MecanicoId == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Mecanicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMecanico(int id)
        {
            var mecanico = await _context.Mecanicos.FindAsync(id);

            if (mecanico == null)
                return NotFound();

            _context.Mecanicos.Remove(mecanico);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
