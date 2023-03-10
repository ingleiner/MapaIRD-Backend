namespace ProyectoIRD.Dominio.Entities.Surveys
{
    public class SurveyAplication: BaseEntity
    {
        public Guid SurveyId { get; set; }
        public Guid PatientId { get; set; }
        public Survey Survey { get; set; }
        public Patient Patient { get; set; }
        public virtual ICollection<Result> Results { get; set; }

    }
}
