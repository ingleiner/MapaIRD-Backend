using Microsoft.Extensions.Options;
using ProyectoIRD.Aplicaciones.Exceptions;
using ProyectoIRD.Aplicaciones.Interfaces.ISurveys;
using ProyectoIRD.Aplicaciones.Interfaces.IUsers;
using ProyectoIRD.Aplicaciones.QueryFilters;
using ProyectoIRD.Dominio.CustomsEntities;
using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Entities.Users;
using ProyectoIRD.Dominio.Enums;
using ProyectoIRD.Dominio.Interfaces.ISurveys;
using ProyectoIRD.Dominio.Utils;

namespace ProyectoIRD.Aplicaciones.Services.Surveys
{
    public class SurveyService : ISurveyService
    {
        private readonly IUnitOfWorkSurvey _unitOfWorkSurvey;
        private readonly IUserService _userService;
        private readonly PaginationOptions _paginationOptions;
        private int orderSection;
        private int orderQuestion;
        private int orderAnswer;
        //private readonly IBaseRepository<Survey> _baseRepository;


        public SurveyService(IUnitOfWorkSurvey unitOfWorkSurvey, IUserService userService, IOptions<PaginationOptions> options)
        {
            _unitOfWorkSurvey = unitOfWorkSurvey;
            _userService = userService;
            _paginationOptions = options.Value;
            orderSection = 0;
            orderQuestion = 0;
            orderAnswer = 0;
        }
        public async Task<Survey> GetSurvey(Guid id)
        {
            return await _unitOfWorkSurvey.SurveyRepository.GetById(id);
        }
        public async Task<Survey> GetFullSurvey(Guid id)
        {
            return await _unitOfWorkSurvey.SurveyRepository.GetFullSurveyById(id);
        }
        public PagedList<Survey> GetSurveys(SurveyQueryFilter filter)
        {
            filter.PageNumber = filter.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filter.PageNumber; 
            filter.PageSize = filter.PageSize == 0 ? _paginationOptions.DefaultPageSize : filter.PageSize;

            var surveys = _unitOfWorkSurvey.SurveyRepository.GetAll();

            if(filter.Title != null)
            {
                surveys = surveys.Where(s => s.Title == filter.Title);
            }
            if(filter.Description != null)
            {
                surveys = surveys.Where(s => s.Description.ToLower().Contains(filter.Description.ToLower()));
            }
            if(filter.Version != null)
            {
                surveys = surveys.Where(s => s.Version == filter.Version);
            }
            if(filter.Validity != null)
            {
                surveys = surveys.Where(s => s.Validity.ToShortDateString() == filter.Validity?.ToShortDateString());
            }
            if(filter.IsActive != null)
            {
                surveys = surveys.Where(s => s.IsActive == filter.IsActive);
            }

            var pagedSurveys = PagedList<Survey>.Create(surveys, filter.PageNumber, filter.PageSize);
            
            return pagedSurveys;
        }
        public async Task<bool> AddSurvey(Survey survey, string userEmail)
        {
            try
            {
                User userDb = await _userService.getUserByEmail(userEmail);
                survey.UserId = userDb.Id;
                survey.IsActive = true;
                survey.CreatedAt = Utils.DateNow();
                survey.UpdatedAt = Utils.DateNow();
                MapAuditData(survey.QuestionSections, userDb.Id);
                await _unitOfWorkSurvey.SurveyRepository.Add(survey);
                await _unitOfWorkSurvey.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("Ha ocurrido un error al guardar la encuesta", ex);
            }
            
        }

        public async Task<Survey> UpdateSurvey(Survey survey, string userEmail)
        {
            var surveyDb = await GetSurvey(survey.Id);
            User userDb = await _userService.getUserByEmail(userEmail);
            if (surveyDb == null)
            {
                throw new BussinesException("La encuesta consultada aún no ha sido creada");;
            }
            if(surveyDb != null)
            {
                surveyDb.Title = survey.Title;
                surveyDb.Description = survey.Description;
                surveyDb.IsActive = survey.IsActive;
                surveyDb.Version = survey.Version;
                surveyDb.Validity = survey.Validity;
                surveyDb.UpdatedAt = Utils.DateNow();
                surveyDb.UserId = userDb.Id;
                _unitOfWorkSurvey.SurveyRepository.Update(surveyDb);
                await _unitOfWorkSurvey.SaveChangesAsync();
            }
            return surveyDb!;
        }
        
        public async Task<bool> UpdateFullSurvey(Survey survey, string userEmail)
        {
            var surveyDb = await GetSurvey(survey.Id);
            if (surveyDb == null)
            {
                throw new BussinesException("La encuesta consultada aún no ha sido creada"); ;
            }
            User userDb = await _userService.getUserByEmail(userEmail);
            
            try
            {
                surveyDb.Title = survey.Title;
                surveyDb.Description = survey.Description;
                surveyDb.IsActive = survey.IsActive;
                surveyDb.Version = survey.Version;
                surveyDb.Validity = survey.Validity;
                surveyDb.IsActive = survey.IsActive;
                surveyDb.UpdatedAt = Utils.DateNow();
                surveyDb.UserId = userDb.Id;
                await MapFullSurveyUpdateData(survey.QuestionSections, userDb.Id, surveyDb.Id);
                _unitOfWorkSurvey.SurveyRepository.Update(surveyDb);
                await _unitOfWorkSurvey.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("Ha ocurrido un error al intentar actualizar la encuesta y sus entidades relacionadas", ex);
            }

        }
        public async Task<bool> DeleteSurvey(Guid id)
        {
            await _unitOfWorkSurvey.SurveyRepository.Delete(id);
            return true;
        }


        /// <summary>
        /// Procedimiento para asignar los datos de auditoria a las entidades Hijas de Encuesta
        /// </summary>
        /// <param name="questionSection"></param>
        /// <param name="userId"></param>
        private void MapAuditData(ICollection<QuestionSection> questionSection, string userId)
        {
             foreach (var section in questionSection)
            {
                section.CreatedAt = Utils.DateNow();
                section.UpdatedAt = Utils.DateNow();
                section.UserId = userId;
                section.Order = orderSection + 1;
                orderSection = orderSection + 1;
                foreach (var question in section.Questions)
                {
                    question.UserId = userId;
                    question.CreatedAt = Utils.DateNow();
                    question.UpdatedAt = Utils.DateNow();
                    question.Order = orderQuestion + 1;
                    question.QuestionType = QuestionType.RespuestaUnica;
                    orderQuestion = orderQuestion + 1;
                    foreach (var answer in question.Answers)
                    {
                        answer.UserId = userId;
                        answer.CreatedAt = Utils.DateNow();
                        answer.UpdatedAt = Utils.DateNow();
                        answer.Order = orderAnswer + 1;
                        orderAnswer = orderAnswer + 1;
                    }
                }
            }
        }
    
        /// <summary>
        /// Mapear los datos de las Secciones, preguntas y opciones de preguntas
        /// En caso de sean nuevas entidades, agregarlas
        /// En caso de que existan, editarlas o eliminarlas según el valor de la propiedad IsToDelete
        /// </summary>
        /// <param name="questionSection"></param>
        /// <param name="userId"></param>
        /// <param name="surveyId"></param>
        /// <returns></returns>
        private async Task MapFullSurveyUpdateData(ICollection<QuestionSection> questionSection, string userId, Guid surveyId)
        {
            foreach (var section in questionSection)
            {
                var sectionDb = await _unitOfWorkSurvey.QSectionRepository.GetById(section.Id);
                if (sectionDb != null)
                {
                    sectionDb.Description = section.Description;
                    sectionDb.UpdatedAt = Utils.DateNow();
                    _unitOfWorkSurvey.QSectionRepository.Update(sectionDb);
                    await _unitOfWorkSurvey.SaveChangesAsync();
                }
                if (sectionDb == null)
                {
                    orderSection = _unitOfWorkSurvey.QSectionRepository.Order(section.SurveyId);
                    sectionDb = new QuestionSection
                    {
                        Description = section.Description,
                        Order = orderSection + 1,
                        CreatedAt = Utils.DateNow(),
                        UpdatedAt = Utils.DateNow(),
                        SurveyId = surveyId,
                        UserId = userId,
                    };
                    await _unitOfWorkSurvey.QSectionRepository.Add(sectionDb);
                    await _unitOfWorkSurvey.SaveChangesAsync();
                };
                foreach (var question in section.Questions)
                {
                    var quiestionDb = await _unitOfWorkSurvey.QuestionRepository.GetById(question.Id);

                    if (quiestionDb != null)
                    {
                        quiestionDb.Description = question.Description;
                        quiestionDb.Item = question.Item;
                        quiestionDb.UpdatedAt = Utils.DateNow();
                        _unitOfWorkSurvey.QuestionRepository.Update(quiestionDb);
                        await _unitOfWorkSurvey.SaveChangesAsync();

                    }
                    if (quiestionDb == null)
                    {
                        orderQuestion = _unitOfWorkSurvey.QuestionRepository.Order(sectionDb.Id);
                        quiestionDb = new Question
                        {
                            Description = question.Description,
                            Order = orderQuestion + 1,
                            Item = question.Item,
                            QuestionSectionId = sectionDb.Id,
                            UserId = userId,
                            QuestionType = QuestionType.RespuestaUnica,
                            CreatedAt = Utils.DateNow(),
                            UpdatedAt = Utils.DateNow()

                        };
                        await _unitOfWorkSurvey.QuestionRepository.Add(quiestionDb);
                        await _unitOfWorkSurvey.SaveChangesAsync();
                    }
                    foreach (var answer in question.Answers)
                    {
                        var answerDb = await _unitOfWorkSurvey.AnswerRepository.GetById(answer.Id);

                        if (answerDb != null)
                        {
                            answerDb.Description = answer.Description;
                            answerDb.UpdatedAt = Utils.DateNow();

                            _unitOfWorkSurvey.AnswerRepository.Update(answerDb);
                            await _unitOfWorkSurvey.SaveChangesAsync();
                        }
                        if (answerDb == null)
                        {
                            orderAnswer = _unitOfWorkSurvey.AnswerRepository.Order(quiestionDb.Id);
                            answerDb = new Answer
                            {
                                Description = answer.Description,
                                Order = orderAnswer + 1,
                                CreatedAt = Utils.DateNow(),
                                UpdatedAt = Utils.DateNow(),
                                QuestionId = quiestionDb.Id,
                                UserId = userId
                            };
                            await _unitOfWorkSurvey.AnswerRepository.Add(answerDb);
                            await _unitOfWorkSurvey.SaveChangesAsync();
                        }
                    }
                        
                }
            }
        }
    }
}
