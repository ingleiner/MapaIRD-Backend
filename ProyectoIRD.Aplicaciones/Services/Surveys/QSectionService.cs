using ProyectoIRD.Aplicaciones.Exceptions;
using ProyectoIRD.Aplicaciones.Interfaces.ISurveys;
using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Interfaces.ISurveys;

namespace ProyectoIRD.Aplicaciones.Services.Surveys
{
    public class QSectionService : IQSectionService
    {
        private readonly IUnitOfWorkSurvey _unitOfWorkSurvey;

        public QSectionService(IUnitOfWorkSurvey unitOfWorkSurvey)
        {
            _unitOfWorkSurvey = unitOfWorkSurvey;
        }
        public async Task<QuestionSection> GetQSection(Guid id)
        {
            return await _unitOfWorkSurvey.QSectionRepository.GetById(id);
        }

        public IEnumerable<QuestionSection> GetQSections()
        {
            return _unitOfWorkSurvey.QSectionRepository.GetAll();
        }
        public async Task<bool> AddQSection(QuestionSection qsection)
        {
            await _unitOfWorkSurvey.QSectionRepository.Add(qsection);
            await _unitOfWorkSurvey.SaveChangesAsync();
            return true;
        }


        public async Task<bool> UpdateQSection(QuestionSection qsection)
        {
            _unitOfWorkSurvey.QSectionRepository.Update(qsection);
            await _unitOfWorkSurvey.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteQSection(Guid id)
        {
            try
            {
                await _unitOfWorkSurvey.QSectionRepository.Delete(id);
                await _unitOfWorkSurvey.SaveChangesAsync();
                return true;
            }
            catch (BussinesException ex)
            {

                throw new BussinesException(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<List<object>> GetGralResultsBySection(Guid surveyId, DateTime searchDate)
        {
            return await _unitOfWorkSurvey.QSectionRepository.GetGralResultsBySection(surveyId, searchDate);
        }
    }
}
