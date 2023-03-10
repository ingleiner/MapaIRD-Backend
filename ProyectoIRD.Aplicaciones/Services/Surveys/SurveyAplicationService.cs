using ProyectoIRD.Aplicaciones.Interfaces.ISurveys;
using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Interfaces.ISurveys;

namespace ProyectoIRD.Aplicaciones.Services.Surveys
{
    public class SurveyAplicationService : ISurveysAplicationService
    {
        private readonly IUnitOfWorkSurvey _unitOfWorkSurvey;

        public SurveyAplicationService(IUnitOfWorkSurvey unitOfWorkSurvey)
        {
            _unitOfWorkSurvey = unitOfWorkSurvey;
        }

        public async Task<bool> AddAplication(SurveyAplication surveyAplication)
        {
            await _unitOfWorkSurvey.SurveryAplicationRepository.Add(surveyAplication);
            await _unitOfWorkSurvey.SaveChangesAsync();
            return true;

        }

        public Task<List<object>> GetResultsBySectionAndQuestions(DateTime searchDate, Guid surveyId)
        {
           return _unitOfWorkSurvey.SurveryAplicationRepository
                    .GetResultsBySectionAndQuestions(searchDate, surveyId); 
        }
        public async Task<int> GetCountAplicationSurvey(Guid surveyId, DateTime searchDate)
        {
            return await _unitOfWorkSurvey.SurveryAplicationRepository.GetCountAplicationSurvey(surveyId, searchDate);
        }
        public async Task<SurveyAplication> GetLastSurveyAplication()
        {
            return await _unitOfWorkSurvey.SurveryAplicationRepository.GetLastSurveyAplication();
        }
    }
}
