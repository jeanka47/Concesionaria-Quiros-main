namespace ConcesionariaQuiros.Models
{
    public class Diagnostico
    {
        public int DiagnosticoId { get; set; }
        public string DescripcionDiagnostico { get; set; } = string.Empty;
        public int RevisionId { get; set; }
    }
}
