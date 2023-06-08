using ProyectoIRD.Dominio.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIRD.Dominio.Entities.Surveys
{
    public class Question : BaseEntity
    {
        public string Description { get; set; }
        public string Item { get; set; }
        public QuestionType QuestionType { get; set; }
        public Guid QuestionSectionId { get; set; }
        public int Order { get; set; }
        public QuestionSection QuestionSection { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<Result> Results { get; set; }

        [NotMapped]
        public bool IsToUpdate { get; set; }

    }
}
