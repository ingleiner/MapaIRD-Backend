using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoIRD.API.Responses;
using ProyectoIRD.Aplicaciones.Interfaces.ISurveys;
using ProyectoIRD.Dominio.DTOs.SurveyDtos;

namespace ProyectoIRD.API.Controllers.Surveys
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultService _resultService;
        private readonly IMapper _mapper;

        public ResultController(IResultService resultService, IMapper mapper)
        {
            _resultService = resultService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetResultsByQuestion([FromQuery] Guid idQuestion, DateTime searchDate)
        {
            var results = await _resultService.GetResultsByQuestion(idQuestion, searchDate);
            ResultsByQuestion resultsByQuestion = new ResultsByQuestion()
            {
                results = results,
            };
            var response = new IRDResponse<ResultsByQuestion>(resultsByQuestion);
            return Ok(response);
        }
        [HttpGet("resultsbysections")]
        public async Task<IActionResult> GetAllResultsBySections([FromQuery] DateTime searchDate)
        {
            var results = await _resultService.GetAllResultBySections(searchDate);
            ResultsByQuestion resultsByQuestion = new ResultsByQuestion()
            {
                results = results,
            };
            var response = new IRDResponse<ResultsByQuestion>(resultsByQuestion);
            return Ok(response);
        }

    }
}
