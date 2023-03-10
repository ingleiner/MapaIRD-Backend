using ProyectoIRD.Dominio.Entities.Users;

namespace ProyectoIRD.Aplicaciones.Interfaces.IUsers
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetRoles();
        Task<Role> GetRoleByName(string RoleName);
        Task<Role> GetRoleById(string Id);
        Task PostRole(Role role);
        Task<bool> PutRole(Role role);
        Task<bool> DeleteRole(Role role);
    }
}
