using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Dominio.DTOs.SurveyDtos
{
    /// <summary>
    /// DTO que se usa para crear las respuesta de una pregunta de
    /// forma individual
    /// </summary>
    public class SingleAnswerDto
    {
        public string Description { get; set; }
        public Guid QuestionId { get; set; }
        public DateTime CreatedAd { get; set; }
        public DateTime UpdatedAd { get; set; }
    }
}
