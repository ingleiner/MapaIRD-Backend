using ProyectoIRD.Dominio.DTOs.UserDtos;
using ProyectoIRD.Dominio.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Aplicaciones.Interfaces.IUsers
{
    public interface IUserService
    {
        Task<bool> RolUser(string RolName);


        Task<ResponseMsg> putUser(string Id, UserRegister userLogin);


        Task<User> getUserByEmail(string email);


        Task<User> getEmailClaim(string email);

        Task<User> getUsuariobyId(string id);
        Task<UserDto> GetUserDtoByEmail(string email);

        Task<IList<string>> GetUserRoles(User user);
    }
}
