using ProyectoIRD.Dominio.Entities.Surveys;

namespace ProyectoIRD.Dominio.Interfaces.ISurveys
{
    public interface IResultRepository : IBaseRepository<Result>
    {
        Task<List<object>> GetResultsyByQuestion(Guid questionId, DateTime searchDate);
        Task<List<object>> GetAllResultsyBySections(DateTime searchDate);
    }
}
