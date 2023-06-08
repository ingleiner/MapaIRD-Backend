using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIRD.Dominio.Entities.Surveys
{
    public class QuestionSection: BaseEntity
    {
        public string Description { get; set; }
        public Guid SurveyId { get; set; }
        public int Order { get; set; }
        public Survey Survey { get; set; }
        public ICollection<Question> Questions { get; set; }

        [NotMapped]
        public bool IsToUpdate { get; set; }
    }
}
