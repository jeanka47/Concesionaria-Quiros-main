namespace ConcesionariaQuiros.Models
{
    public class Reparacion
    {
        public int ReparacionId { get; set; }
        public string TipoReparacion { get; set; } = string.Empty;
        public string MotivoReparacion { get; set; } = string.Empty;
        public float CostoReparacion { get; set; }
        public DateTime FechaIngreso { get; set; }  
        public DateTime FechaEgreso { get; set; }
        public int RevisionId { get; set; }

    }
}
