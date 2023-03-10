namespace ProyectoIRD.Dominio.DTOs.SurveyDtos
{
    /// <summary>
    /// DTO que representa la creacion de una pregunta de forma individual
    /// con sus respectiva sección y typo de pregunta previamente creados
    /// </summary>
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid QuestionTypeId { get; set; }
        public Guid QuestionSectionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<AnswerDto> Answers { get; set; }
    }
}
