using ConcesionariaQuiros.Data;
using ConcesionariaQuiros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcesionariaQuiros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevisionesController : ControllerBase
    {
        private readonly ConcesionariaContext _context;

        // Inyección del DbContext
        public RevisionesController(ConcesionariaContext context)
        {
            _context = context;
        }

        // GET: api/Revisiones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Revision>>> GetRevisiones()
        {
            return await _context.Revisiones.ToListAsync();
        }

        // GET: api/Revisiones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Revision>> GetRevision(int id)
        {
            var revision = await _context.Revisiones.FindAsync(id);

            if (revision == null)
                return NotFound();

            return revision;
        }

        // POST: api/Revisiones
        [HttpPost]
        public async Task<ActionResult<Revision>> PostRevision(Revision revision)
        {
            _context.Revisiones.Add(revision);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetRevision),
                new { id = revision.RevisionId },
                revision
            );
        }

        // PUT: api/Revisiones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRevision(int id, Revision revision)
        {
            if (id != revision.RevisionId)
                return BadRequest();

            _context.Entry(revision).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Revisiones.Any(e => e.RevisionId == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Revisiones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRevision(int id)
        {
            var revision = await _context.Revisiones.FindAsync(id);

            if (revision == null)
                return NotFound();

            _context.Revisiones.Remove(revision);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
