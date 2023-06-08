namespace ProyectoIRD.Dominio.DTOs.SurveyDtos
{
    /// <summary>
    /// DTO que representa una posible respuesta asociada a una pregunta
    /// Se utiliza para crear la encuesta completa
    /// </summary>
    public class AnswerDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }
        public int Order { get; set; }
        public bool IsToUpdate { get; set; }
    }
}
