using ProyectoIRD.Aplicaciones.Interfaces.ISurveys;
using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Interfaces.ISurveys;

namespace ProyectoIRD.Aplicaciones.Services.Surveys
{
    public class ResultService : IResultService
    {
        private readonly IUnitOfWorkSurvey _unitOfWorkSurvey;

        public ResultService(IUnitOfWorkSurvey unitOfWorkSurvey)
        {
            _unitOfWorkSurvey = unitOfWorkSurvey;
        }
        public async Task<Result> GetResult(Guid id)
        {
            return await _unitOfWorkSurvey.ResultRepository.GetById(id);
        }

        public IEnumerable<Result> GetResults()
        {
            return _unitOfWorkSurvey.ResultRepository.GetAll();
        }
        public async Task<bool> AddResult(Result result)
        {
            var question = await _unitOfWorkSurvey.QuestionRepository.GetById(result.QuestionId);

            if (question == null)
            {
                return false;
            }
            await _unitOfWorkSurvey.ResultRepository.Add(result);
            await _unitOfWorkSurvey.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateResult(Result result)
        {
            _unitOfWorkSurvey.ResultRepository.Update(result);
            await _unitOfWorkSurvey.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteResult(Guid id)
        {
            await _unitOfWorkSurvey.ResultRepository.Delete(id);
            return true;
        }
        public async Task<List<object>> GetResultsByQuestion(Guid questionId, DateTime searchDate)
        {
            return await _unitOfWorkSurvey.ResultRepository.GetResultsyByQuestion(questionId, searchDate);
        }

        public async Task<List<object>> GetAllResultBySections(DateTime searchDate)
        {
            return await _unitOfWorkSurvey.ResultRepository.GetAllResultsyBySections(searchDate);
        }
    }
}
