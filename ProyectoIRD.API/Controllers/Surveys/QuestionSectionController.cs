using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoIRD.API.Responses;
using ProyectoIRD.Aplicaciones.Interfaces.ISurveys;
using ProyectoIRD.Aplicaciones.Interfaces.IUsers;
using ProyectoIRD.Dominio.DTOs.SurveyDtos;
using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Entities.Users;
using ProyectoIRD.Dominio.Utils;
using System.IdentityModel.Tokens.Jwt;

namespace ProyectoIRD.API.Controllers.Surveys
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class QuestionSectionController : ControllerBase
    {
        private readonly IQSectionService _qSectionService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public QuestionSectionController(IQSectionService qSectionService, IMapper mapper,
                                        IUserService userService)
        {
            _qSectionService = qSectionService;
            _mapper = mapper;
            _userService = userService;
        }
        [HttpGet]
        public IActionResult GetQSections()
        {
            var qSections = _qSectionService.GetQSections();
            var qSectionsDto = _mapper.Map<IEnumerable<QSectionDto>>(qSections);
            var response = new IRDResponse<IEnumerable<QSectionDto>>(qSectionsDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> PostQSection(QSectionDto qSectionDto)
        {
            try
            {
                var qSection = _mapper.Map<QuestionSection>(qSectionDto);
                var emailClaim = HttpContext.User.Claims
                       .Where(claim => claim.Type == JwtRegisteredClaimNames.Email).FirstOrDefault();
                var email = emailClaim!.Value;
                User userDb = await _userService.getUserByEmail(email);
                qSection.UserId = userDb.Id;
                qSection.CreatedAt = Utils.DateNow();
                qSection.UpdatedAt = Utils.DateNow();
                
                await _qSectionService.AddQSection(qSection);
                qSectionDto = _mapper.Map<QSectionDto>(qSection);
                var response = new IRDResponse<QSectionDto>(qSectionDto);
                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("gralresultsbysection")]
        public async Task<IActionResult> GetGralResultsBySection([FromQuery] string surveyId, DateTime searchDate)
        {
            var results = await _qSectionService.GetGralResultsBySection(Guid.Parse(surveyId), searchDate);
            ResultsByQuestion resultsByQuestion = new ResultsByQuestion()
            {
                results = results,
            };
            var response = new IRDResponse<ResultsByQuestion>(resultsByQuestion);
            return Ok(response);
        }
    }
}
