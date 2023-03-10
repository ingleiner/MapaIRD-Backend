namespace ProyectoIRD.Dominio.DTOs.SurveyDtos
{
    public class SurveyAplicationData
    {
        public string SurveyId { get; set; }
        public PatientDto Patient { get; set; }
        public ICollection<ResultDto> Results { get; set; }
    }
}
