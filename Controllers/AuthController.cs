using ConcesionariaQuiros.Data;
using ConcesionariaQuiros.Models;
using ConcesionariaQuiros.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcesionariaQuiros.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ConcesionariaContext _context;
        private readonly JwtService _jwtService;

        public AuthController(
            ConcesionariaContext context,
            JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (usuario == null)
            {
                return Unauthorized(new
                {
                    mensaje = "Correo o contraseña incorrectos."
                });
            }

            var contrasenaCorrecta = BCrypt.Net.BCrypt.Verify(
                request.Contrasena,
                usuario.Contrasena
            );

            if (!contrasenaCorrecta)
            {
                return Unauthorized(new
                {
                    mensaje = "Correo o contraseña incorrectos."
                });
            }

            var token = _jwtService.GenerarToken(usuario);

            return Ok(new
            {
                mensaje = "Inicio de sesión correcto.",
                token,
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