using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Interfaces.ISurveys;
using ProyectoIRD.Infraestructura.Datos.Data;

namespace ProyectoIRD.Infraestructura.Datos.Repositories.Surveys
{
    public class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(MapaIRDContext context) : base(context)
        {
        }

        public int Order(Guid questionId)
        {
            int maxOrden = 0;
            var seccion = _entities.Where(s => s.QuestionId == questionId).OrderByDescending(s => s.Order).FirstOrDefault();
            if (seccion != null)
            {
                maxOrden = seccion.Order;
            }
            return maxOrden;
        }
    }
}
