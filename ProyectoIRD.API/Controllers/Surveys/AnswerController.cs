using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoIRD.API.Responses;
using ProyectoIRD.Aplicaciones.Interfaces.ISurveys;
using ProyectoIRD.Aplicaciones.Interfaces.IUsers;
using ProyectoIRD.Aplicaciones.Services;
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
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public AnswerController(IAnswerService answerService, IMapper mapper,
                                IUserService userService)
        {
            _answerService = answerService;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAnswers()
        {
            var answers = _answerService.GetAnswers();
            var answersDto = _mapper.Map<IEnumerable<AnswerDto>>(answers);
            var response = new IRDResponse<IEnumerable<AnswerDto>>(answersDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> PostAnswer(AnswerDto answerDto)
        {
            try
            {

                var answer = _mapper.Map<Answer>(answerDto);
                var emailClaim = HttpContext.User.Claims
                       .Where(claim => claim.Type == JwtRegisteredClaimNames.Email).FirstOrDefault();
                var email = emailClaim!.Value;
                User userDb = await _userService.getUserByEmail(email);
                answer.UserId = userDb.Id;
                answer.CreatedAt = Utils.DateNow();
                answer.UpdatedAt = Utils.DateNow();
                await _answerService.UpdateAnswer(answer);

                answerDto = _mapper.Map<AnswerDto>(answer);
                var response = new IRDResponse<AnswerDto>(answerDto);
                return Ok(response); 
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
