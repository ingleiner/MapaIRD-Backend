using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoIRD.API.Responses;
using ProyectoIRD.Aplicaciones.Interfaces.IUsers;
using ProyectoIRD.Dominio.DTOs.UserDtos;
using ProyectoIRD.Dominio.Entities.Users;

namespace ProyectoIRD.API.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
    public class RoleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;

        public RoleController(IMapper mapper, IRoleService roleService)
        {
            _mapper = mapper;
            _roleService = roleService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(RolDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);
            await _roleService.PostRole(role);

            roleDto = _mapper.Map<RolDto>(role);
            var response = new IRDResponse<RolDto>(roleDto);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleService.GetRoles();
            var rolesDto = _mapper.Map<IEnumerable<RolDto>>(roles);

            var response = new IRDResponse<IEnumerable<RolDto>>(rolesDto);
            return Ok(response);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetRoleById(string id)
        {
            var rol = await _roleService.GetRoleById(id);
            var roleDto = _mapper.Map<RolDto>(rol);
            var response = new IRDResponse<RolDto>(roleDto);
            return Ok(response);
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetRoleByName(string name)
        {
            var rol = await _roleService.GetRoleByName(name);
            var roleDto = _mapper.Map<RolDto>(rol);
            var response = new IRDResponse<RolDto>(roleDto);
            return Ok(response);
        }
    }
}
