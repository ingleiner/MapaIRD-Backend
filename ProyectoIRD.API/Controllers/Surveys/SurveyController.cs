using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoIRD.API.Responses;
using ProyectoIRD.Aplicaciones.Interfaces.ISurveys;
using ProyectoIRD.Aplicaciones.Interfaces.IUsers;
using ProyectoIRD.Dominio.DTOs.SurveyDtos;
using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Entities.Users;
using ProyectoIRD.Dominio.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace ProyectoIRD.API.Controllers.Surveys
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ISurveysAplicationService _aplicationService;

        public SurveyController(ISurveyService surveyService, IMapper mapper,
               IUserService userService,
               ISurveysAplicationService aplicationService)
        {
            _surveyService = surveyService;
            _mapper = mapper;
            _userService = userService;
            _aplicationService = aplicationService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSurveyById(string id, [FromQuery] DateTime searchDate)
        {
            var survey = await _surveyService.GetSurvey(Guid.Parse(id));
            var numAplication = await _aplicationService.GetCountAplicationSurvey(Guid.Parse(id), searchDate);

            var surveyDto = _mapper.Map<SurveyDto>(survey);
            surveyDto.Aplications = numAplication;
            var response = new IRDResponse<SurveyDto>(surveyDto);

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetSurveys()
        {
            var surveys = _surveyService.GetSurveys();
            var surveysDto = _mapper.Map<ICollection<SurveyDto>>(surveys);
            var response = new IRDResponse<ICollection<SurveyDto>>(surveysDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostSurvey([FromBody] SurveyDto surveyDto)
        {
            try
            {
                var survey = _mapper.Map<Survey>(surveyDto);
                
                var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == JwtRegisteredClaimNames.Email).FirstOrDefault();
                var email = emailClaim!.Value;
                User userDb = await _userService.getUserByEmail(email);
                survey.UserId = userDb.Id;
                survey.IsActive = true;
                survey.CreatedAt = Utils.DateNow();
                survey.UpdatedAt = Utils.DateNow();
                await _surveyService.AddSurvey(survey);

                return Ok(new { message = " Se agregó la encuesta correctamente" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("fullsurvey")]
        public async Task<IActionResult> PostFullSurvey(FullSurveyDto fullSurveyDto)
        {
            try
            {
                Survey fullSurvey = _mapper.Map<Survey>(fullSurveyDto);
                var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == JwtRegisteredClaimNames.Email).FirstOrDefault();
                var email = emailClaim!.Value;
                User userDb = await _userService.getUserByEmail(email);
                fullSurvey.UserId = userDb.Id;
                fullSurvey.IsActive = true;
                fullSurvey.CreatedAt = Utils.DateNow();
                fullSurvey.UpdatedAt = Utils.DateNow();
                MapAuditData(fullSurvey.QuestionSections, userDb.Id);
                await _surveyService.AddSurvey(fullSurvey);
                return Ok(new { message = " Se agregó la encuesta  correctamente" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }


        /// <summary>
        /// Obtener una Encuesta con sus secciones, preguntas y posibles respuestas
        /// de acuerdo al id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("fullsurvey/{id}")]
        public async Task<IActionResult> GetFullSurvey(Guid id)
        {
            var survey = await _surveyService.GetFullSurvey(id);
            foreach(var secion in survey.QuestionSections)
            {
                foreach(var question in secion.Questions)
                {
                    question.QuestionType.ToString();
                }
            }
            var surveyDto = _mapper.Map<FullSurveyDto>(survey);
            return Ok(surveyDto);
        }

        /// <summary>
        /// Procedimiento para asignar los datos de auditoria a las entidades Hijas de Encuesta
        /// </summary>
        /// <param name="questionSection"></param>
        /// <param name="userId"></param>
        private void MapAuditData(ICollection<QuestionSection> questionSection, string userId)
        {
            var orderSection = 0;
            foreach(var section in questionSection)
            {
                section.CreatedAt = Utils.DateNow();
                section.UpdatedAt = Utils.DateNow();
                section.UserId =userId;
                section.Order = orderSection + 1;
                var orderQuestion = 0;
                foreach(var question in section.Questions)
                {
                    question.UserId = userId;
                    question.CreatedAt = Utils.DateNow();
                    question.UpdatedAt = Utils.DateNow();
                    question.Order = orderQuestion + 1;
                    var orderAnswer = 0;
                    foreach (var answer in question.Answers)
                    {
                        answer.UserId = userId;
                        answer.CreatedAt = Utils.DateNow();
                        answer.UpdatedAt = Utils.DateNow();
                        answer.Order = orderAnswer + 1;
                    }
                }
            }
        }
    }
}
