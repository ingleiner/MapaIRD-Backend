using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Interfaces.ISurveys;
using ProyectoIRD.Infraestructura.Datos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Infraestructura.Datos.Repositories.Surveys
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(MapaIRDContext context) : base(context)
        {
        }

        public int Order(Guid sectionId)
        {
            int maxOrden = 0;
            var seccion = _entities.Where(q => q.QuestionSectionId == sectionId).OrderByDescending(s => s.Order).FirstOrDefault();
            if (seccion != null)
            {
                maxOrden = seccion.Order;
            }
            return maxOrden;
        }
    }
}
