using ProyectoIRD.Aplicaciones.QueryFilters;
using ProyectoIRD.Dominio.CustomsEntities;
using ProyectoIRD.Dominio.Entities;
using ProyectoIRD.Dominio.Entities.Surveys;

namespace ProyectoIRD.Aplicaciones.Interfaces.ISurveys
{
    public interface ISurveyService
    {
        PagedList<Survey> GetSurveys(SurveyQueryFilter filter);
        Task<Survey> GetSurvey(Guid id);
        Task<Survey> GetFullSurvey(Guid id);
        Task<bool> AddSurvey(Survey survey, string userEmail);
        Task<Survey> UpdateSurvey(Survey survey, string userEmail);
        Task<bool> UpdateFullSurvey(Survey survey, string userEmail);
        Task<bool> DeleteSurvey(Guid id);

    }
}
