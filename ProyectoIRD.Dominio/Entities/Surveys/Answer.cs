namespace ProyectoIRD.Dominio.Entities.Surveys
{
 
    public class Answer: BaseEntity
    {
        public  string Description { get; set; }
        public Guid QuestionId { get; set; }
        public int Order { get; set; }
        public virtual Question Question { get; set; }
        public virtual ICollection<Result> Results { get; set; }

    }
}
