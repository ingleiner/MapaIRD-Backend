using ProyectoIRD.Dominio.Entities;
using ProyectoIRD.Dominio.Entities.Surveys;

namespace ProyectoIRD.Aplicaciones.Interfaces.ISurveys
{
    public interface ISurveyService
    {
        IEnumerable<Survey> GetSurveys();
        Task<Survey> GetSurvey(Guid id);
        Task<Survey> GetFullSurvey(Guid id);
        Task<bool> AddSurvey(Survey survey);
        Task<bool> UpdateSurvey(Survey survey);
        Task<bool> DeleteSurvey(Guid id);

    }
}
