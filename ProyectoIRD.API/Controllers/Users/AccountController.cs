using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoIRD.API.Responses;
using ProyectoIRD.Aplicaciones.Interfaces.IUsers;
using ProyectoIRD.Dominio.DTOs.UserDtos;
using System.Security.Claims;

namespace ProyectoIRD.API.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAccountUserService _accountUserService;
        private readonly ITokenService _tokenService;

        public AccountController(IMapper mapper, IAccountUserService accountUserService,
            ITokenService tokenService)
        {
            _mapper = mapper;
            _accountUserService = accountUserService;
            _tokenService = tokenService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegister userRegister)
        {
            var result = await _accountUserService.RegisterUser(userRegister);
            //var response = new IRDResponse<ResponseMsg>(result);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            var result = await _accountUserService.LoginUser(userLogin);
            //var response = new IRDResponse<ResponseMsg>(result);
            return Ok(result);
        }

        [HttpGet("renewtoken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult RenewToken()
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim!.Value;
            UserRegister userlogin = new UserRegister()
            {
                Email = email,
            };
            var result = _accountUserService.RenewToken(userlogin);
            //var response = new IRDResponse<ResponseMsg>(result);
            return Ok(result);
        }

    }
}
