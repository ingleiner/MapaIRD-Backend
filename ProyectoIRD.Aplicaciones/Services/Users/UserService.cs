using ProyectoIRD.Aplicaciones.Interfaces.IUsers;
using ProyectoIRD.Dominio.DTOs.UserDtos;
using ProyectoIRD.Dominio.Entities.Users;
using ProyectoIRD.Dominio.Interfaces.IUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Aplicaciones.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
       
        public Task<User> getUserByEmail(string email)
        {
            return _userRepository.getUserByEmail(email);
        }

        public Task<UserDto> GetUserDtoByEmail(string email)
        {
            return _userRepository.GetUserDtoByEmail(email);
        }

        public Task<User> getUsuariobyId(string id)
        {
            return _userRepository.getUsuariobyId(id);
        }

        public async Task<IList<string>> GetUserRoles(User user)
        {
            return await _userRepository.GetUserRoles(user);
        }

        public Task<ResponseMsg> putUser(string Id, UserRegister userLogin)
        {
            throw new NotImplementedException();
        }
        public Task<User> getEmailClaim(string email)
        {
            throw new NotImplementedException();
        }
        public Task<bool> RolUser(string RolName)
        {
            throw new NotImplementedException();
        }


    }
}
