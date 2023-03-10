namespace ProyectoIRD.Dominio.DTOs.SurveyDtos
{
    public class SurveyDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Version { get; set; }
        public bool IsActive { get; set; }
        public DateTime Validity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } 
        public int? Aplications { get; set; }
    }
}
