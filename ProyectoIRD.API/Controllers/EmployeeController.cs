using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoIRD.API.Responses;
using ProyectoIRD.Aplicaciones.Interfaces;
using ProyectoIRD.Dominio.DTOs;
using ProyectoIRD.Dominio.Entities;

namespace ProyectoIRD.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _mapper = mapper;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetEmployees();
            var employeeDto = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);

            var response = new IRDResponse<IEnumerable<EmployeeDTO>>(employeeDto);
            return Ok(response);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(Guid id)
        {
            var employee = await _employeeService.GetEmployee(id);
            var employeeDto = _mapper.Map<EmployeeDTO>(employee);
            var response = new IRDResponse<EmployeeDTO>(employeeDto);
            return Ok(response);    
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> PostEmployee(EmployeeDTO employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _employeeService.AddEmployee(employee);

            employeeDto = _mapper.Map<EmployeeDTO>(employee);
            var response = new IRDResponse<EmployeeDTO>(employeeDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> PutEmployee(Guid id, EmployeeDTO employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            employee.Id = id;

            var restult = await _employeeService.UpdateEmployee(employee);
            var response = new IRDResponse<bool>(restult);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var result = await _employeeService.DeleteEmployee(id);
            var response = new IRDResponse<bool>(result);
            return Ok(response);
        }
    }
}
