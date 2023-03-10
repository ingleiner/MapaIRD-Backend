using ProyectoIRD.Dominio.Entities.Surveys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Aplicaciones.Interfaces.ISurveys
{
    /// <summary>
    /// Interface que define la lógica de negocio sobre la entidad Resultado
    /// para una pretunta de una encuesta
    /// </summary>
    public interface IResultService
    {
        IEnumerable<Result> GetResults();
        Task<Result> GetResult(Guid id);
        Task<bool> AddResult(Result result);
        Task<bool> UpdateResult(Result result);
        Task<bool> DeleteResult(Guid id);
        Task<List<object>> GetResultsByQuestion(Guid questionId, DateTime searchDate);
        Task<List<object>> GetAllResultBySections(DateTime searchDate);
    }
}
