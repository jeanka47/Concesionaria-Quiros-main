using ConcesionariaQuiros.Data;
using ConcesionariaQuiros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcesionariaQuiros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticosController : ControllerBase
    {
        private readonly ConcesionariaContext _context;

        // Inyección del DbContext
        public DiagnosticosController(ConcesionariaContext context)
        {
            _context = context;
        }

        // GET: api/Diagnosticos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diagnostico>>> GetDiagnosticos()
        {
            return await _context.Diagnosticos.ToListAsync();
        }

        // GET: api/Diagnosticos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diagnostico>> GetDiagnostico(int id)
        {
            var diagnostico = await _context.Diagnosticos.FindAsync(id);

            if (diagnostico == null)
                return NotFound();

            return diagnostico;
        }

        // POST: api/Diagnosticos
        [HttpPost]
        public async Task<ActionResult<Diagnostico>> PostDiagnostico(Diagnostico diagnostico)
        {
            _context.Diagnosticos.Add(diagnostico);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetDiagnostico),
                new { id = diagnostico.DiagnosticoId },
                diagnostico
            );
        }

        // PUT: api/Diagnosticos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiagnostico(int id, Diagnostico diagnostico)
        {
            if (id != diagnostico.DiagnosticoId)
                return BadRequest();

            _context.Entry(diagnostico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Diagnosticos.Any(e => e.DiagnosticoId == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Diagnosticos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiagnostico(int id)
        {
            var diagnostico = await _context.Diagnosticos.FindAsync(id);

            if (diagnostico == null)
                return NotFound();

            _context.Diagnosticos.Remove(diagnostico);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
