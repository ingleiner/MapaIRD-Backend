using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Enums;

namespace ProyectoIRD.Dominio.DTOs.SurveyDtos
{
    /// <summary>
    /// DTO que representa una pregunta con un listado de posibles respuestas
    /// Se utiliza para crear la encuesta completa
    /// </summary>
    public class QuestionAndAnswerDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string QuestionType { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }
        public int Order { get; set; }
        public ICollection<AnswerDto> Answers { get; set; }
    }
}
