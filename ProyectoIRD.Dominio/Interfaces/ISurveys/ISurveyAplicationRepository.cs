using ProyectoIRD.Dominio.Entities.Surveys;

namespace ProyectoIRD.Dominio.Interfaces.ISurveys
{
    public interface ISurveyAplicationRepository: IBaseRepository<SurveyAplication>
    {
        Task<List<object>> GetResultsBySectionAndQuestions(DateTime searchDate, Guid surveyId);
        Task<int> GetCountAplicationSurvey(Guid surveyId, DateTime searchDate);
        Task<SurveyAplication> GetLastSurveyAplication();

    }
}
