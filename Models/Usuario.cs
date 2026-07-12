namespace ConcesionariaQuiros.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string rol { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;

    }
}
