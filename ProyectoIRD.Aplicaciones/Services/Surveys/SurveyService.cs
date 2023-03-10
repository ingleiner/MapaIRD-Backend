using ProyectoIRD.Aplicaciones.Interfaces.ISurveys;
using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Interfaces.ISurveys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Aplicaciones.Services.Surveys
{
    public class SurveyService : ISurveyService
    {
        private readonly IUnitOfWorkSurvey _unitOfWorkSurvey;

        //private readonly IBaseRepository<Survey> _baseRepository;


        public SurveyService(IUnitOfWorkSurvey unitOfWorkSurvey)
        {
            _unitOfWorkSurvey = unitOfWorkSurvey;
        }
        public async Task<Survey> GetSurvey(Guid id)
        {
            return await _unitOfWorkSurvey.SurveyRepository.GetById(id);
        }
        public async Task<Survey> GetFullSurvey(Guid id)
        {
            return await _unitOfWorkSurvey.SurveyRepository.GetFullSurveyById(id);
        }
        public IEnumerable<Survey> GetSurveys()
        {
            var surveys = _unitOfWorkSurvey.SurveyRepository.GetAll();
            return surveys;
        }
        public async Task<bool> AddSurvey(Survey survey)
        {
            await _unitOfWorkSurvey.SurveyRepository.Add(survey);
            await _unitOfWorkSurvey.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateSurvey(Survey survey)
        {
            _unitOfWorkSurvey.SurveyRepository.Update(survey);
            await _unitOfWorkSurvey.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteSurvey(Guid id)
        {
            await _unitOfWorkSurvey.SurveyRepository.Delete(id);
            return true;
        }
    }
}
