using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoIRD.API.Responses;
using ProyectoIRD.Aplicaciones.Interfaces.ISurveys;
using ProyectoIRD.Dominio.DTOs.SurveyDtos;

namespace ProyectoIRD.API.Controllers.Surveys
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SurveyAplicationController : ControllerBase
    {
        private readonly ISurveysAplicationService _aplicationService;
        private readonly IMapper _mapper;

        public SurveyAplicationController(ISurveysAplicationService aplicationService,
                                            IMapper mapper)
        {
            _aplicationService = aplicationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetResultsBySectionsAndQuestions([FromQuery] string surveyId, DateTime searchDate)
        {

            var results = await _aplicationService.GetResultsBySectionAndQuestions(searchDate, Guid.Parse(surveyId));
            ResultsByQuestion resultsByQuestion = new ResultsByQuestion()
            {
                results = results,
            };
            var response = new IRDResponse<ResultsByQuestion>(resultsByQuestion);
            return Ok(response);
        }
        [HttpGet("lastsurveyaplication")]
        public async Task<IActionResult> GetLastSurveyAplication()
        {
            var surveyAplication = await _aplicationService.GetLastSurveyAplication();
            if(surveyAplication == null)
            {
                return BadRequest("No se ha aplicado ningula encuesta aún");
            }
            var aplicationDto = _mapper.Map<SurveyAplicationDto>(surveyAplication);
            var response = new IRDResponse<SurveyAplicationDto>(aplicationDto);
            return Ok(response);
        }
    }
}
