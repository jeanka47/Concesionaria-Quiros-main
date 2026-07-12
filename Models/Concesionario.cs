namespace ConcesionariaQuiros.Models
{
    public class Concesionario
    {
        public int ConcesionarioId { get; set; }
        public string NombreConcesionario { get; set; } = string.Empty;
        public string Provincia { get; set; } = string.Empty;
        public string Canton { get; set; } = string.Empty;
        public string Distrito { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
