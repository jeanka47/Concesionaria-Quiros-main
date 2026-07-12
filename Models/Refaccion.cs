namespace ConcesionariaQuiros.Models
{
    public class Refaccion
    {
        public int RefaccionId { get; set; }
        public string NombreRefaccion { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public float PrecioRefaccion { get; set; }
        public int DiagnosticoId { get; set; }

    }
}
