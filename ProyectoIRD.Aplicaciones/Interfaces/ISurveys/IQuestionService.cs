using ProyectoIRD.Dominio.Entities.Surveys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Aplicaciones.Interfaces.ISurveys
{
    /// <summary>
    /// Interfaz que define la lógica de negocio para la Entidad Pregunta
    /// </summary>
    public interface IQuestionService
    {
        IEnumerable<Question> GetQuestions();
        Task<Question> GetQuestion(Guid id);
        Task<bool> AddQuestion(Question question);
        Task<bool> UpdateQuestion(Question question);
        Task<bool> DeleteQuestion(Guid id);
    }
}
