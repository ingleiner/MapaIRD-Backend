namespace ProyectoIRD.Dominio.DTOs.SurveyDtos
{
    /// <summary>
    /// DTO que representa una Seccion con listado de Preguntas
    /// Se utiliza para crear la encuesta completa
    /// </summary>
    public class SectionAndQuestionDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public DateTime CreatedAt { get; set; } = Utils.Utils.DateNow();
        public DateTime UpdatedAt { get; set; } = Utils.Utils.DateNow();
        public ICollection<QuestionAndAnswerDto> Questions { get; set; }
    }
}
