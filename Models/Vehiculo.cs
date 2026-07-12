using System.ComponentModel.DataAnnotations.Schema;

namespace ConcesionariaQuiros.Models
{
    public class Vehiculo
    {
        public int VehiculoId { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Extras { get; set; } = string.Empty;
        public string Combustible { get; set; } = string.Empty;
        public string TipoVehiculo { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Matricula { get; set; } = string.Empty;
        public decimal Kilometraje { get; set; }
        public int ConcesionarioId { get; set; } 
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool Disponible { get; set; }
    }
}
