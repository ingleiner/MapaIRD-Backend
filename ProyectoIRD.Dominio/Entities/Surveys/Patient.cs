namespace ProyectoIRD.Dominio.Entities.Surveys
{
    public class Patient : BaseEntity
    {
        public string TypeDocument { get; set; }
        public string DocumentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EPS { get; set; }
        public string MedicalStudy { get; set; }
        public string Phone { get; set; }
        public ICollection<SurveyAplication> SurveyAplications { get; set; }
    }
}
