using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcesionariaQuiros.Models
{
    public class Vehiculo
    {
        public int VehiculoId { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria.")]
        [StringLength(50, ErrorMessage = "La marca no puede superar los 50 caracteres.")]
        public string Marca { get; set; } = string.Empty;

        [Required(ErrorMessage = "El modelo es obligatorio.")]
        [StringLength(80, ErrorMessage = "El modelo no puede superar los 80 caracteres.")]
        public string Modelo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El color es obligatorio.")]
        [StringLength(40, ErrorMessage = "El color no puede superar los 40 caracteres.")]
        public string Color { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Los extras no pueden superar los 500 caracteres.")]
        public string Extras { get; set; } = string.Empty;

        [Required(ErrorMessage = "El tipo de combustible es obligatorio.")]
        [StringLength(30, ErrorMessage = "El combustible no puede superar los 30 caracteres.")]
        public string Combustible { get; set; } = string.Empty;

        [Required(ErrorMessage = "El tipo de vehículo es obligatorio.")]
        [StringLength(40, ErrorMessage = "El tipo de vehículo no puede superar los 40 caracteres.")]
        public string TipoVehiculo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [StringLength(30, ErrorMessage = "El estado no puede superar los 30 caracteres.")]
        public string Estado { get; set; } = string.Empty;

        [Required(ErrorMessage = "La matrícula es obligatoria.")]
        [StringLength(20, ErrorMessage = "La matrícula no puede superar los 20 caracteres.")]
        public string Matricula { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "El kilometraje no puede ser negativo.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Kilometraje { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un concesionario válido.")]
        public int ConcesionarioId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El precio de compra no puede ser negativo.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioCompra { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El precio de venta no puede ser negativo.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioVenta { get; set; }

        public bool Disponible { get; set; }
    }
}