using ProyectoIRD.Aplicaciones.Interfaces.IUsers;
using ProyectoIRD.Dominio.DTOs;
using ProyectoIRD.Dominio.Entities.Users;
using ProyectoIRD.Dominio.Interfaces.IUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Aplicaciones.Services.Users
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<IEnumerable<Role>> GetRoles()
        {
            return await _roleRepository.GetRoles();
        }
        public async Task<Role> GetRoleById(string Id)
        {
            return await _roleRepository.GetRoleById(Id);
        }

        public async Task<Role> GetRoleByName(string RoleName)
        {
            return await _roleRepository.GetRoleByName(RoleName);
        }

        public async Task PostRole(Role role)
        {
            await _roleRepository.PostRole(role);
        }

        public async Task<bool> PutRole(Role role)
        {
            return await _roleRepository.PutRole(role);
        }
        public Task<bool> DeleteRole(Role role)
        {
            return _roleRepository.DeleteRole(role);
        }
    }
}
