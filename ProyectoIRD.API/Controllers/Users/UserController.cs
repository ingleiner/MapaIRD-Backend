using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProyectoIRD.API.Responses;
using ProyectoIRD.Aplicaciones.Interfaces.IUsers;
using ProyectoIRD.Dominio.DTOs.UserDtos;
using System.IdentityModel.Tokens.Jwt;

namespace ProyectoIRD.API.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userService.getUsuariobyId(id);
            var userDto = _mapper.Map<UserDto>(user);
            var response = new IRDResponse<UserDto>(userDto);
            return Ok(response);
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == JwtRegisteredClaimNames.Email).FirstOrDefault();
            var email = emailClaim!.Value;
            var user = await _userService.getUserByEmail(email);
            var userDto = _mapper.Map<UserDto>(user);
            var roles = await _userService.GetUserRoles(user);
            userDto.RolNames = roles.ToList();
            var response = new IRDResponse<UserDto>(userDto);
            return Ok(response);

        }
    }
}
