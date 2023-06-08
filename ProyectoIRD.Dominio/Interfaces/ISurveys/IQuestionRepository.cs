using ProyectoIRD.Dominio.Entities.Surveys;

namespace ProyectoIRD.Dominio.Interfaces.ISurveys
{
    public interface IQuestionRepository: IBaseRepository<Question>
    {
        public int Order(Guid sectionId);
    }
}
