namespace ConcesionariaQuiros.Models
{
    public class Persona
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido1 { get; set; } = string.Empty;
        public string Apellido2 { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;  
        public string Direccion { get; set; } = string.Empty;

    }
}
