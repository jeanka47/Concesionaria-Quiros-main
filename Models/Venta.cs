namespace ConcesionariaQuiros.Models
{
    public class Venta
    {
        public int VentaId { get; set; }
        public DateTime FechaVenta { get; set; }
        public DateTime FechaGarantia { get; set; }
        public float TotalVenta { get; set; }
        public int VendedorId { get; set; }
        public int ConcesionarioId { get; set; }
        public int PersonaId { get; set; }
        public int VehiculoId { get; set; }
    }
}
