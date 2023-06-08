using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProyectoIRD.API.Responses;
using ProyectoIRD.Aplicaciones.Interfaces.ISurveys;
using ProyectoIRD.Aplicaciones.Interfaces.IUsers;
using ProyectoIRD.Aplicaciones.QueryFilters;
using ProyectoIRD.Dominio.CustomsEntities;
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
    //TODO: Configurar permisos de acceso por roles
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

        [HttpGet("{id}", Name = nameof(GetSurveyById))]
        public async Task<IActionResult> GetSurveyById(string id, [FromQuery] DateTime searchDate)
        {
            var survey = await _surveyService.GetSurvey(Guid.Parse(id));
            var numAplication = await _aplicationService.GetCountAplicationSurvey(Guid.Parse(id), searchDate);

            var surveyDto = _mapper.Map<SurveyDto>(survey);
            surveyDto.Aplications = numAplication;
            var response = new IRDResponse<SurveyDto>(surveyDto);

            return Ok(response);
        }

        [HttpGet(Name = nameof(GetSurveys))]
        public IActionResult GetSurveys([FromQuery] SurveyQueryFilter filter)
        {
            var surveys = _surveyService.GetSurveys(filter);
            var surveysDto = _mapper.Map<ICollection<SurveyDto>>(surveys);

            var metaData = new MetaData
            {
              TotalCount = surveys.TotalCount,
              PageSize =  surveys.PageSize,
              CurrentPage =  surveys.CurrentPage,
              TotalPages = surveys.TotalPages,
              HasNextPage =  surveys.HasNextPage,
              HasPreviousPage = surveys.HasPreviousPage,
            };
            //Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));

            var response = new IRDResponse<ICollection<SurveyDto>>(surveysDto)
            {
                Meta = metaData,
            };
            return Ok(response);
        }

        [HttpPost(Name = nameof(PostSurvey))]
        public async Task<IActionResult> PostSurvey([FromBody] SurveyDto surveyDto)
        {
                var survey = _mapper.Map<Survey>(surveyDto);
                
                var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == JwtRegisteredClaimNames.Email).FirstOrDefault();
                var userEmail = emailClaim!.Value;
                await _surveyService.AddSurvey(survey, userEmail);

                return Ok(new { message = " Se agregó la encuesta correctamente" });
        }

        [HttpPost("fullsurvey", Name = nameof(PostFullSurvey))]
        public async Task<IActionResult> PostFullSurvey(FullSurveyDto fullSurveyDto)
        {
            Survey fullSurvey = _mapper.Map<Survey>(fullSurveyDto);
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == JwtRegisteredClaimNames.Email).FirstOrDefault();
            var userEmail = emailClaim!.Value;
                
            await _surveyService.AddSurvey(fullSurvey, userEmail);
            return Ok(new { message = " Se agregó la encuesta  correctamente" });
        }


        [HttpGet("fullsurvey/{surveyId}", Name = nameof(GetFullSurvey))]
        public async Task<IActionResult> GetFullSurvey(string surveyId)
        {
            var survey = await _surveyService.GetFullSurvey(Guid.Parse(surveyId));
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

        [HttpPut("updatefullsurvey", Name = nameof(UpdateFullSurvey))]
        public async Task<IActionResult> UpdateFullSurvey(FullSurveyDto fullSurveyDto)
        {
            Survey fullSurvey = _mapper.Map<Survey>(fullSurveyDto);
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == JwtRegisteredClaimNames.Email).FirstOrDefault();
            var userEmail = emailClaim!.Value;            
            await _surveyService.UpdateFullSurvey(fullSurvey, userEmail);
            return Ok(new { message = "Se ha actualizado la Encuesta correctamente" });
        }

        [HttpPut("updatesurvey")]
        public async Task<IActionResult> UpdateSurvey(SurveyDto surveyDto)
        {
            Survey survey = _mapper.Map<Survey>(surveyDto);
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == JwtRegisteredClaimNames.Email).FirstOrDefault();
            var userEmail = emailClaim!.Value;
            survey = await _surveyService.UpdateSurvey(survey, userEmail);

            var message = new
            {
                message = "Se ha actualizado la Encuesta correctamente"
            };
            surveyDto = _mapper.Map<SurveyDto>(survey);
            var response = new IRDResponse<SurveyDto>(surveyDto)
            {
                Message = message
            };

            return Ok(response);
        }
    }
}
