using ProyectoIRD.Dominio.DTOs.UserDtos;
using ProyectoIRD.Dominio.Entities.Users;

namespace ProyectoIRD.Dominio.Interfaces.IUsers
{
    public interface IUserRepository
    {
        Task<User> getUserByEmail(string email);
        Task<User> getUsuariobyId(string id);
        Task<UserDto> GetUserDtoByEmail(string email);
        Task<IList<string>> GetUserRoles(User user);
    }
}
