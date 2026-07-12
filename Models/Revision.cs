namespace ConcesionariaQuiros.Models
{
    public class Revision
    {
        public int RevisionId { get; set; }
      public string TipoRevision { get; set; }  = string.Empty;
        public string EstadoRevisión { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public int MecanicoId { get; set; }
    }
}
