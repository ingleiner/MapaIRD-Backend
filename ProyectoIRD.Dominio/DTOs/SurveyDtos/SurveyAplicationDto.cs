namespace ProyectoIRD.Dominio.DTOs.SurveyDtos
{
    public class SurveyAplicationDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid PatientId { get; set; }
        public Guid SurveyId { get; set; }
        //public virtual ICollection<ResultDto> Results { get; set; }
    }
}
