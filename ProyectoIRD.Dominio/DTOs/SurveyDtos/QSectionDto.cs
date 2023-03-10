using ProyectoIRD.Dominio.Entities.Surveys;

namespace ProyectoIRD.Dominio.DTOs.SurveyDtos
{
    public class QSectionDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid SurveyId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
