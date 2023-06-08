using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoIRD.API.Responses;
using ProyectoIRD.Aplicaciones.Interfaces.ISurveys;
using ProyectoIRD.Aplicaciones.Interfaces.IUsers;
using ProyectoIRD.Aplicaciones.Services.Surveys;
using ProyectoIRD.Dominio.DTOs.SurveyDtos;
using ProyectoIRD.Dominio.Entities.Surveys;
using ProyectoIRD.Dominio.Entities.Users;
using ProyectoIRD.Dominio.Interfaces;
using ProyectoIRD.Dominio.Utils;
using System.Data;
using System.IdentityModel.Tokens.Jwt;

namespace ProyectoIRD.API.Controllers.Surveys
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public QuestionController(IQuestionService questionService, IMapper mapper,
                                   IUserService userService)
        {
            _questionService = questionService;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> PostQuestion(QuestionDto questionDto)
        {
            try
            {
                var question = _mapper.Map<Question>(questionDto);
                
                var emailClaim = HttpContext.User.Claims
                       .Where(claim => claim.Type == JwtRegisteredClaimNames.Email).FirstOrDefault();
                var email = emailClaim!.Value;
                User userDb = await _userService.getUserByEmail(email);
                question.UserId = userDb.Id;
                question.CreatedAt = Utils.DateNow();
                question.UpdatedAt = Utils.DateNow();
                foreach(var answer in question.Answers)
                {
                    answer.CreatedAt = Utils.DateNow();
                    answer.UpdatedAt = Utils.DateNow();
                    answer.UserId = userDb.Id;
                }
                    await _questionService.AddQuestion(question);
                questionDto = _mapper.Map<QuestionDto>(question);
                var response = new IRDResponse<QuestionDto>(questionDto);
                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
          
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion(Guid id)
        {
            var question = await _questionService.GetQuestion(id);
            var questionDto = _mapper.Map<QuestionDto>(question);
            var response = new IRDResponse<QuestionDto>(questionDto);
            return Ok(response);
        }
        [HttpGet]
         public IActionResult GetQuestions()
         {
            var questions = _questionService.GetQuestions();
            var questionDto = _mapper.Map<QuestionDto>(questions);
            var response = new IRDResponse<QuestionDto>(questionDto);
            return Ok(response);
         }
        [HttpDelete("{questionId}")]
        public async Task<IActionResult> DeleteQuestion(string questionId)
        {
            await _questionService.DeleteQuestion(Guid.Parse(questionId));
            var message = new
            {
                message = "Se ha eliminado la pregunta correctamente"
            };
            return Ok(message);
        }
    }
}
