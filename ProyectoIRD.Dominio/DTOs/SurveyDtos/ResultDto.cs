namespace ProyectoIRD.Dominio.DTOs.SurveyDtos
{
    public class ResultDto
    {
        public Guid SurveyAplicationId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid? AnswerId { get; set; }
        public string? Description { get; set; }
        
    }
}
