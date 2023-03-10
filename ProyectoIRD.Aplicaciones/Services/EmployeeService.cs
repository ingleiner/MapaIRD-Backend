using ProyectoIRD.Aplicaciones.Interfaces;
using ProyectoIRD.Dominio.Entities;
using ProyectoIRD.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Aplicaciones.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task AddEmployee(Employee employee)
        {
            await _employeeRepository.AddEmployee(employee);
        }

        public async Task<Employee> GetEmployee(Guid id)
        {
            var employee = await _employeeRepository.GetEmployee(id);
            if(null == employee)
            {
                throw new Exception("El usuario no existe");
            }
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeRepository.GetEmployees();
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
           return await _employeeRepository.UpdateEmployee(employee);
                   
        }

        public Task<bool> DeleteEmployee(Guid id)
        {
            return _employeeRepository.DeleteEmployee(id);
        }
    }
}
