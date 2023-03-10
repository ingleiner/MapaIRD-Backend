namespace ProyectoIRD.Dominio.Entities.Surveys
{
    public class Survey : BaseEntity
    {
     
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int Version { get; set; }
        public DateTime Validity { get; set; }
        public virtual ICollection<QuestionSection> QuestionSections { get; set; }
        public virtual ICollection<SurveyAplication> SurveyAplications { get; set; }

    }
}
