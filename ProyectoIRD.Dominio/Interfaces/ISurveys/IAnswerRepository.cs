using ProyectoIRD.Dominio.Entities.Surveys;

namespace ProyectoIRD.Dominio.Interfaces.ISurveys
{
    public interface IAnswerRepository: IBaseRepository<Answer>
    {
        public int Order(Guid questionId);
    }
}
