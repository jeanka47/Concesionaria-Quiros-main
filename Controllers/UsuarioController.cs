using ConcesionariaQuiros.Data;
using ConcesionariaQuiros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcesionariaQuiros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ConcesionariaContext _context;

        public UsuariosController(ConcesionariaContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioResponse>>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios
                .Select(usuario => new UsuarioResponse
                {
                    UsuarioId = usuario.UsuarioId,
                    NombreUsuario = usuario.NombreUsuario,
                    Email = usuario.Email,
                    Rol = usuario.rol
                })
                .ToListAsync();

            return Ok(usuarios);
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioResponse>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios
                .Where(usuario => usuario.UsuarioId == id)
                .Select(usuario => new UsuarioResponse
                {
                    UsuarioId = usuario.UsuarioId,
                    NombreUsuario = usuario.NombreUsuario,
                    Email = usuario.Email,
                    Rol = usuario.rol
                })
                .FirstOrDefaultAsync();

            if (usuario == null)
            {
                return NotFound(new
                {
                    mensaje = "Usuario no encontrado."
                });
            }

            return Ok(usuario);
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<UsuarioResponse>> PostUsuario(Usuario usuario)
        {
            usuario.Contrasena =
                BCrypt.Net.BCrypt.HashPassword(usuario.Contrasena);

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var respuesta = new UsuarioResponse
            {
                UsuarioId = usuario.UsuarioId,
                NombreUsuario = usuario.NombreUsuario,
                Email = usuario.Email,
                Rol = usuario.rol
            };

            return CreatedAtAction(
                nameof(GetUsuario),
                new { id = usuario.UsuarioId },
                respuesta
            );
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return BadRequest(new
                {
                    mensaje = "El identificador del usuario no coincide."
                });
            }

            var usuarioExistente = await _context.Usuarios.FindAsync(id);

            if (usuarioExistente == null)
            {
                return NotFound(new
                {
                    mensaje = "Usuario no encontrado."
                });
            }

            usuarioExistente.NombreUsuario = usuario.NombreUsuario;
            usuarioExistente.Email = usuario.Email;
            usuarioExistente.rol = usuario.rol;

            // Solo cambia y protege la contraseña si se envía una nueva.
            if (!string.IsNullOrWhiteSpace(usuario.Contrasena))
            {
                usuarioExistente.Contrasena =
                    BCrypt.Net.BCrypt.HashPassword(usuario.Contrasena);
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound(new
                {
                    mensaje = "Usuario no encontrado."
                });
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}