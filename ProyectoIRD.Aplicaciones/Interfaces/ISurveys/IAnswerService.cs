using ProyectoIRD.Dominio.Entities.Surveys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Aplicaciones.Interfaces.ISurveys
{
    /// <summary>
    /// Interfaz de Servicio que define las reglas de negocio sobrela la 
    /// entidad Respuesta de una pregunta en específico
    /// </summary>
    public interface IAnswerService
    {
        IEnumerable<Answer> GetAnswers();
        Task<Answer> GetAnswer(Guid id);
        Task<bool> AddAnswer(Answer answer);
        Task<bool> UpdateAnswer(Answer answer);
        Task<bool> DeleteAnswer(Guid id);
    }
}
