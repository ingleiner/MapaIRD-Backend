using ProyectoIRD.Dominio.Entities.Surveys;

namespace ProyectoIRD.Dominio.Interfaces.ISurveys
{
    public interface IQuestionSectionRepository: IBaseRepository<QuestionSection>
    {
        Task<List<object>> GetGralResultsBySection(Guid surveyId, DateTime searchDate);
        public int Order(Guid surveyId);
    }
}
