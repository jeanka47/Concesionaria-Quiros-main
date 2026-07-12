namespace ConcesionariaQuiros.Models
{
    public class Trabajador
    {
        public int TrabajadorId { get; set; }
        public string TipoTrabajador { get; set; } = string.Empty;
        public float Salario { get; set; }
        public int PersonaId { get; set; }
        public int UsuarioId { get; set; }
    }
}
