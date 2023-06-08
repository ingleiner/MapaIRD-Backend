using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Dominio.DTOs.SurveyDtos
{
    /// <summary>
    /// DTO que representa una Encuesta con un listado de Secciones
    /// </summary>
    public class FullSurveyDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Version { get; set; }
        public DateTime Validity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public ICollection<SectionAndQuestionDto> QuestionSections { get; set; }

    }
}
