namespace ConcesionariaQuiros.Models
{
    public class UsuarioResponse
    {
        public int UsuarioId { get; set; }

        public string NombreUsuario { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Rol { get; set; } = string.Empty;
    }
}