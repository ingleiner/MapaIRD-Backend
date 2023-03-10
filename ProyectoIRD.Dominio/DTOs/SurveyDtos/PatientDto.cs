namespace ProyectoIRD.Dominio.DTOs.SurveyDtos
{
    public class PatientDto
    {
        public string TypeDocument { get; set; }
        public string DocumentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EPS { get; set; }
        public string MedicalStudy { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
