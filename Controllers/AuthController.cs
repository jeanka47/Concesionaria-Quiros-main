using ConcesionariaQuiros.Data;
using ConcesionariaQuiros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcesionariaQuiros.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ConcesionariaContext _context;

        public AuthController(ConcesionariaContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u =>
                    u.Email == request.Email &&
                    u.Contrasena == request.Contrasena);

            if (usuario == null)
            {
                return Unauthorized(new
                {
                    mensaje = "Correo o contraseña incorrectos."
                });
            }

            return Ok(new
            {
                mensaje = "Inicio de sesión correcto.",
                usuario = new
                {
                    usuario.UsuarioId,
                    usuario.NombreUsuario,
                    usuario.Email,
                    usuario.rol
                }
            });
        }
    }
}