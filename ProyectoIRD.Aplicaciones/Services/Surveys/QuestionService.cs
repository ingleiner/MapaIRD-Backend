using ProyectoIRD.Aplicaciones.Interfaces.ISurveys;
using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Interfaces.ISurveys;

namespace ProyectoIRD.Aplicaciones.Services.Surveys
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWorkSurvey _unitOfWorkSurvey;

        public QuestionService(IUnitOfWorkSurvey unitOfWorkSurvey)
        {
            _unitOfWorkSurvey = unitOfWorkSurvey;
        }
        public async Task<Question> GetQuestion(Guid id)
        {
            return await _unitOfWorkSurvey.QuestionRepository.GetById(id);
        }

        public IEnumerable<Question> GetQuestions()
        {
            return _unitOfWorkSurvey.QuestionRepository.GetAll();
        }
        public async Task<bool> AddQuestion(Question question)
        {
            var qSection = await _unitOfWorkSurvey.QSectionRepository.GetById(question.QuestionSectionId);
            if (qSection == null)
            {
                return false;
            }
            await _unitOfWorkSurvey.QuestionRepository.Add(question);
            await _unitOfWorkSurvey.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateQuestion(Question question)
        {
            _unitOfWorkSurvey.QuestionRepository.Update(question);
            await _unitOfWorkSurvey.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteQuestion(Guid id)
        {
            await _unitOfWorkSurvey.QuestionRepository.Delete(id);
            await _unitOfWorkSurvey.SaveChangesAsync();
            return true;
        }
    }
}
