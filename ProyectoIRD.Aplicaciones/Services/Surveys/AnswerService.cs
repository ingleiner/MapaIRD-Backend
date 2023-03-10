using ProyectoIRD.Aplicaciones.Interfaces.ISurveys;
using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Interfaces.ISurveys;

namespace ProyectoIRD.Aplicaciones.Services.Surveys
{
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWorkSurvey _unitOfWorkSurvey;

        public AnswerService(IUnitOfWorkSurvey unitOfWorkSurvey)
        {
            _unitOfWorkSurvey = unitOfWorkSurvey;
        }
        public async Task<Answer> GetAnswer(Guid id)
        {
            return await _unitOfWorkSurvey.AnswerRepository.GetById(id);
        }

        public IEnumerable<Answer> GetAnswers()
        {
            return _unitOfWorkSurvey.AnswerRepository.GetAll();
        }
        public async Task<bool> AddAnswer(Answer answer)
        {
            var question = await _unitOfWorkSurvey.QuestionRepository.GetById(answer.QuestionId);
            if (question == null)
            {
                return false;
            }
            await _unitOfWorkSurvey.AnswerRepository.Add(answer);
            await _unitOfWorkSurvey.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAnswer(Answer answer)
        {
            _unitOfWorkSurvey.AnswerRepository.Update(answer);
            await _unitOfWorkSurvey.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAnswer(Guid id)
        {
            await _unitOfWorkSurvey.AnswerRepository.Delete(id);
            return true;
        }
    }
}
