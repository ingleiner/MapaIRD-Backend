using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProyectoIRD.Dominio.DTOs;
using ProyectoIRD.Dominio.Entities.Users;
using ProyectoIRD.Dominio.Interfaces.IUsers;
using ProyectoIRD.Infraestructura.Datos.Data;

namespace ProyectoIRD.Infraestructura.Datos.Repositories.Users
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly MapaIRDContext _context;

        public RoleRepository(RoleManager<Role> roleManager, MapaIRDContext context)
        {
            _roleManager = roleManager;
            _context = context;
        }
        public async Task<IEnumerable<Role>> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }

        public async Task<Role> GetRoleByName(string RoleName)
        {
            var role = await _roleManager.FindByNameAsync(RoleName);
            return role!;
        }
        public async Task<Role> GetRoleById(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            return role!;
        }
        public async Task PostRole(Role role)
        {
            await _roleManager.CreateAsync(role);
        }

        public async Task<bool> PutRole(Role role)
        {
            await _roleManager.UpdateAsync(role);
            return true;
        }
        public async Task<bool> DeleteRole(Role role)
        {
            await _roleManager.DeleteAsync(role);
            return true;
        }


    }
}
