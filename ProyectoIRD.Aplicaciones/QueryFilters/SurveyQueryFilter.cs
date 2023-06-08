namespace ProyectoIRD.Aplicaciones.QueryFilters
{
    public class SurveyQueryFilter
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public int? Version { get; set; }
        public DateTime? Validity { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
