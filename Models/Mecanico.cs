namespace ConcesionariaQuiros.Models
{
    public class Mecanico
    {
        public int MecanicoId { get; set; }
        public string Especialidad { get; set; } = string.Empty;
        public int TrabajadorId { get; set; }
    }
}
