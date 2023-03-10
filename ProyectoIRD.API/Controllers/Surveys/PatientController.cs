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
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IAnswerService _answerService;
        private readonly ISurveysAplicationService _aplicationService;

        public PatientController(IPatientService patientService, IMapper mapper,
                                IUserService userService,
                                IAnswerService answerService,
                                ISurveysAplicationService aplicationService)
        {
            _patientService = patientService;
            _mapper = mapper;
            _userService = userService;
            _answerService = answerService;
            _aplicationService = aplicationService;
        }
        [HttpPost]
        public async Task<IActionResult> PostPatient([FromBody]SurveyAplicationData aplicationData)
        {
            try
            {
                var patient = _mapper.Map<Patient>(aplicationData.Patient);
                var results = _mapper.Map<ICollection<Result>>(aplicationData.Results);
                var emailClaim = HttpContext.User.Claims
                       .Where(claim => claim.Type == JwtRegisteredClaimNames.Email).FirstOrDefault();
                var email = emailClaim!.Value;
                User userDb = await _userService.getUserByEmail(email);
                patient.UserId = userDb.Id;
                patient.CreatedAt = Utils.DateNow();
                patient.UpdatedAt = Utils.DateNow();

                var patientDb = await _patientService.GetByDocument(patient.DocumentId);
                var patientDbId = patient.Id;
                if (patientDb == null)
                {
                    await _patientService.AddPatient(patient);
                }
                else
                {
                    patientDbId = patientDb.Id;
                }
                await MapResulsData(results, userDb.Id);

                SurveyAplication aplication = new SurveyAplication
                {
                    UserId = userDb.Id,
                    SurveyId = Guid.Parse(aplicationData.SurveyId),
                    CreatedAt = Utils.DateNow(),
                    UpdatedAt = Utils.DateNow(),
                    Results = results,
                    PatientId = patientDbId
                };
                await _aplicationService.AddAplication(aplication);

                return Ok(new { message = " Se aplicó a la encuesta satisfactoriamente" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        private async Task MapResulsData(ICollection<Result> results,
                                    string userId)
        {
            foreach (var result in results)
            {
                var answer = await _answerService.GetAnswer((Guid)result.AnswerId!);
                if (answer != null)
                {
                    result.QuestionId = answer.QuestionId;
                }
                result.AnswerId = (Guid)result.AnswerId!;
                result.UserId = userId;
                result.CreatedAt = Utils.DateNow();
                result.UpdatedAt = Utils.DateNow();
            }
        }

    }
}
