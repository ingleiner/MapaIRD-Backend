using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Interfaces.ISurveys;
using ProyectoIRD.Infraestructura.Datos.Data;

namespace ProyectoIRD.Infraestructura.Datos.Repositories.Surveys
{
    public class ResultRepository : BaseRepository<Result>, IResultRepository
    {
        public ResultRepository(MapaIRDContext context) : base(context)
        {
        }
        /// <summary>
        /// Obtener la cantidad de veces que una opcion de respuesta fue escogia 
        /// a nivel de sección
        /// </summary>
        /// <param name="searchDate"></param>
        /// <returns></returns>
        public async Task<List<object>> GetAllResultsyBySections(DateTime searchDate)
        {
            var results = await _entities.Include(r => r.Answer)
                                         .Include(r => r.Question)
                                         .Where(r => r.CreatedAt.Year == searchDate.Year &&
                                                 r.CreatedAt.Month == searchDate.Month)
                                         .GroupBy(r =>new {Section = r.Question.QuestionSection.Description, 
                                                           Answer = r.Answer.Description })
                                         .Select(r => new
                                         {
                                             Section = r.Key.Section,
                                             Answer = r.Select(r => r.Answer)
                                                                 .GroupBy(a => a.Description)
                                                                 .Select(gr => new
                                                                 {
                                                                     Answer = gr.Key,
                                                                     Count = gr.Count()
                                                                 })
                                         }).ToListAsync();
            return results.Cast<object>().ToList(); ;
        }
        /// <summary>
        /// Obtener la cantidad de veces que se escogió un opción de respuestas 
        /// de una pregunta en específico
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="searchDate"></param>
        /// <returns></returns>
        public async Task<List<object>> GetResultsyByQuestion(Guid questionId, DateTime searchDate)
        {
            var results = await _entities
                            .Where(r => r.CreatedAt.Year == searchDate.Year &&
                                    r.CreatedAt.Month == searchDate.Month &&
                                    r.QuestionId == questionId)
                            .Include(r => r.Question)
                            .Include(r => r.Answer)
                            .GroupBy(r => new { Question = r.Question.Description, Answer = r.Answer.Description })
                            .Select(r => new
                            {
                                Question = r.Key.Question,
                                Answer = r.Key.Answer,
                                Count = r.Count()
                            })
                            .ToListAsync();

            return results.Cast<object>().ToList();

        }
    }
}
