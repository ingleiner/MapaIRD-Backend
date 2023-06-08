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
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }
        public bool IsToUpdate { get; set; }
        public ICollection<QuestionAndAnswerDto> Questions { get; set; }
    }
}
