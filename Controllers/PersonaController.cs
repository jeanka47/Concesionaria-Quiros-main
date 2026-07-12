using ConcesionariaQuiros.Data;
using ConcesionariaQuiros.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcesionariaQuiros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        //Db Context injection
        private readonly ConcesionariaContext _context;
        public PersonaController(ConcesionariaContext context)
        {
            _context = context;
        }
        //Primer endpoint
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            return await _context.Personas.ToListAsync();
        }
        //Post para agregar una persona
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPersonas), new { id = persona.PersonaId }, persona);
        }
        //Get por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
                return NotFound();
            return persona;
        }
        // Put para actualizar una persona
        [HttpPut("{id}")]

        public async Task<IActionResult> PutPersona(int id, Persona persona)
        {
            if (id != persona.PersonaId)
                return BadRequest();
            _context.Entry(persona).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Personas.Any(e => e.PersonaId == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // Delete para eliminar una persona
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
                return NotFound();
            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
