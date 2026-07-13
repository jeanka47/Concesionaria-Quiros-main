using ConcesionariaQuiros.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ConcesionariaQuiros.Services
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerarToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.UsuarioId.ToString()),
                new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.rol)
            };

            var clave = _configuration["Jwt:Key"]
                ?? throw new InvalidOperationException("La clave JWT no está configurada.");

            var llave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(clave)
            );

            var credenciales = new SigningCredentials(
                llave,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credenciales
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}