using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Interfaces.ISurveys;
using ProyectoIRD.Infraestructura.Datos.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace ProyectoIRD.Infraestructura.Datos.Repositories.Surveys
{
    public class SurveyAplicationRepository : BaseRepository<SurveyAplication>, ISurveyAplicationRepository
    {
        private readonly MapaIRDContext _context;

        public SurveyAplicationRepository(MapaIRDContext context): base(context)
        {
            _context = context;
        }
        public async Task<List<object>> GetResultsBySectionAndQuestions(DateTime searchDate, Guid surveyId)
        {
            var results =  _entities.Include(sa => sa.Results)
                                    .ThenInclude(sa => sa.Answer)
                                    .Include(sa => sa.Survey)
                                       .ThenInclude(sa => sa.QuestionSections)
                                       .ThenInclude(sa => sa.Questions)
                                    .Where(sa => sa.CreatedAt.Year == searchDate.Year &&
                                                  sa.CreatedAt.Month == searchDate.Month
                                                  && sa.SurveyId == surveyId)
                                    .SelectMany(sa => sa.Results)
                                    .GroupBy(r => new
                                    {
                                        SeccionId = r.Question.QuestionSection.Id,
                                        Section = r.Question.QuestionSection.Description,
                                        SectionOrder = r.Question.QuestionSection.Order,
                                        QuestionId= r.Question.Id,
                                        Question = r.Question.Description,
                                        QuestionOrder = r.Question.Order,
                                        AnswerId = r.Answer.Id,
                                        Answer = r.Answer.Description,
                                        AnswerOrder = r.Answer.Order
                                    })
                                    .Select(r => new
                                    {
                                        SectionId = r.Key.SeccionId,
                                        Section = r.Key.Section,
                                        SectionOrder = r.Key.SectionOrder,
                                        QuestionId = r.Key.QuestionId,
                                        Question = r.Key.Question,
                                        QuestionOrder = r.Select(q => q.Question.Order).FirstOrDefault(),
                                        AnswerId = r.Key.AnswerId,
                                        Answer = r.Key.Answer,
                                        AnswerOrder = r.Select(q => q.Answer.Order).FirstOrDefault(),
                                        Count = r.Count()
                                    }).ToList()
                                    .OrderBy(so => so.SectionOrder)
                                    .ThenBy(so => so.QuestionOrder)
                                    .ThenBy(ao => ao.AnswerOrder)
                                    .GroupBy(s => s.Section)
                                    .ToDictionary(r => r.Key,
                                                    r => r.GroupBy(r =>  r.Question)
                                                            .ToDictionary(qg => qg.Key,
                                                                qg => qg.Select(r => new
                                                                {
                                                                    AnswerId = r.AnswerId,
                                                                    Answer = r.Answer,
                                                                    Order = r.AnswerOrder,
                                                                    Count = r.Count
                                                                }).ToList()));

            return  results.Cast<object>().ToList();


        }

        public async Task<int> GetCountAplicationSurvey(Guid surveyId, DateTime searchDate)
        {
            return await _entities.CountAsync(a => a.SurveyId == surveyId
                                    && a.CreatedAt.Year == searchDate.Year
                                    && a.CreatedAt.Month == searchDate.Month);
        }

        public async Task<SurveyAplication> GetLastSurveyAplication()
        {
            var surveyAplication = await _entities.OrderByDescending(sa => sa.CreatedAt)
                                    .FirstOrDefaultAsync();
            return surveyAplication!;
        }

        

    }
}
    