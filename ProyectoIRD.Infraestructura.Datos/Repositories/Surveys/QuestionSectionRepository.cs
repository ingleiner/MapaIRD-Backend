using Microsoft.EntityFrameworkCore;
using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Interfaces.ISurveys;
using ProyectoIRD.Infraestructura.Datos.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Infraestructura.Datos.Repositories.Surveys
{
    public class QuestionSectionRepository : BaseRepository<QuestionSection>, IQuestionSectionRepository
    {
        public QuestionSectionRepository(MapaIRDContext context) : base(context)
        {
        }

        public async Task<List<object>> GetGralResultsBySection(Guid surveyId, DateTime searchDate)
        {
            var query = from seccion in _entities
                        where seccion.SurveyId == surveyId
                                && seccion.Survey.SurveyAplications.Any(sa => sa.CreatedAt.Year == searchDate.Year
                                                                            && sa.CreatedAt.Month == searchDate.Month)
                        orderby seccion.Order
                        select new
                        {
                            Seccion = seccion.Description,
                            Preguntas = from pregunta in seccion.Questions
                                    orderby pregunta.Order
                                    select new
                                    {
                                        Pregunta = pregunta.Item,
                                        Satisfaccion = pregunta.Results.Where(r => (r.Answer.Description == "Excelente"
                                                                                || r.Answer.Description == "Bueno"
                                                                                || r.Answer.Description == "Definitivamen Si"
                                                                                || r.Answer.Description == "Probablemente Si")
                                                                                && r.CreatedAt.Year == searchDate.Year 
                                                                                && r.CreatedAt.Month == searchDate.Month)
                                                                        .Count(),
                                        Insatisfaccion = pregunta.Results.Where(r => (r.Answer.Description == "Regular"
                                                                                || r.Answer.Description == "Malo"
                                                                                || r.Answer.Description == "Definitivamen No"
                                                                                || r.Answer.Description == "Probablemente No")
                                                                                && r.CreatedAt.Year == searchDate.Year
                                                                                && r.CreatedAt.Month == searchDate.Month)
                                                                        .Count()
                                    }
                        };

            return await query.Cast<object>().ToListAsync();

        }


        public async Task<List<object>> GetResultsByMonth(Guid surveyId, DateTime searchDate)
        {
            var query = from seccion in _entities
                        where seccion.SurveyId == surveyId
                        from aplicacion in seccion.Survey.SurveyAplications
                        where aplicacion.CreatedAt.Year == searchDate.Year
                        group seccion by new { Month = aplicacion.CreatedAt.Month, Year = aplicacion.CreatedAt.Year } into seccionesPorMes
                        select new
                        {
                            Mes = seccionesPorMes.Key.Month,
                            Anio = seccionesPorMes.Key.Year,
                            Secciones = from seccion in seccionesPorMes
                                        orderby seccion.Order
                                        select new
                                        {
                                            Seccion = seccion.Description,
                                            Satisfaccion = (from pregunta in seccion.Questions
                                                            let respuestas = pregunta.Results
                                                            let totalRespuestas = respuestas.Where(r => r.CreatedAt.Year == searchDate.Year).Count()
                                                            where totalRespuestas > 0
                                                            select respuestas.Count(r => r.Answer.Description == "Excelente" 
                                                                                        || r.Answer.Description == "Bueno")
                                                           ).Sum(),
                                            Insatisfaccion = (from pregunta in seccion.Questions
                                                              let respuestas = pregunta.Results
                                                              let totalRespuestas = respuestas.Where(r => r.CreatedAt.Year == searchDate.Year).Count()
                                                              where totalRespuestas > 0
                                                              select respuestas.Count(r => r.Answer.Description == "Regular" || r.Answer.Description == "Malo")
                                                              ).Sum()
                                        }
                        };

            return await query.Cast<object>().ToListAsync();
        }
    }
}
