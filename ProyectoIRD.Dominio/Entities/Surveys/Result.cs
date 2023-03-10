namespace ProyectoIRD.Dominio.Entities.Surveys
{
    public class Result : BaseEntity
    {
        public string? Description { get; set; }
        public Guid? AnswerId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid SurveyAplicationId { get; set; }
        public int Order { get; set; } 
        public Answer Answer { get; set; }
        public Question Question { get; set; }
        public SurveyAplication SurveyAplication { get; set; }
    }
}
