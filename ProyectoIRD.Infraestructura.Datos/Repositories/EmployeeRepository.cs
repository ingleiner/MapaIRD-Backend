using Microsoft.EntityFrameworkCore;
using ProyectoIRD.Dominio.Entities;
using ProyectoIRD.Dominio.Interfaces;
using ProyectoIRD.Infraestructura.Datos.Data;

namespace ProyectoIRD.Infraestructura.Datos.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly MapaIRDContext _context;

        public EmployeeRepository(MapaIRDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employee = await _context.Employees.ToListAsync();
            return employee;
        }

        public async Task<Employee> GetEmployee(Guid id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(u => u.Id == id);
            return employee!;
        }

        public async Task AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            var currentemployee = await GetEmployee(employee.Id);
            currentemployee.IdentityCard = employee.IdentityCard;
            currentemployee.FirstName = employee.FirstName;
            currentemployee.LastName = employee.LastName;
            currentemployee.Email = employee.Email;
            currentemployee.PersonalPhone = employee.PersonalPhone;
            currentemployee.WorkPhone = employee.WorkPhone;
            currentemployee.JobTitle = employee.JobTitle;
            currentemployee.IsActive = employee.IsActive;

            int rowsAfected = await _context.SaveChangesAsync();
            return rowsAfected > 0;
        }

        public async Task<bool> DeleteEmployee(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee!);
            int rowsAfected = await _context.SaveChangesAsync();
            return rowsAfected > 0;
        }
    }
}
