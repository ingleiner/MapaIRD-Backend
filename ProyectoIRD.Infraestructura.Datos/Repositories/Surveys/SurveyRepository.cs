using Microsoft.EntityFrameworkCore;
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
    public class SurveyRepository : BaseRepository<Survey>, ISurveyRepository
    {
        public SurveyRepository(MapaIRDContext context) : base(context)
        {

        }

        public async Task<Survey> GetFullSurveyById(Guid surveyId)
        {
            var survey = await _entities.Where(s => s.Id == surveyId)
                                .Include(qs => qs.QuestionSections.OrderBy(o => o.Order))
                                .ThenInclude(q => q.Questions.OrderBy(o => o.Order))
                                .ThenInclude(a => a.Answers.OrderBy(o => o.Order))
                                .FirstOrDefaultAsync();
            return survey!;
        }
    }
}
