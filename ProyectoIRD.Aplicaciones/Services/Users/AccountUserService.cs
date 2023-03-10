using ProyectoIRD.Aplicaciones.Interfaces.IUsers;
using ProyectoIRD.Dominio.DTOs.UserDtos;
using ProyectoIRD.Dominio.Interfaces.IUsers;

namespace ProyectoIRD.Aplicaciones.Services.Users
{
    public class AccountUserService : IAccountUserService
    {
        private readonly IAccountUserRepository _accountUserRepository;

        public AccountUserService(IAccountUserRepository accountUserRepository)
        {
            _accountUserRepository = accountUserRepository;
        }
        public async Task<ResponseMsg> RegisterUser(UserRegister userRegister)
        {
            return await _accountUserRepository.RegisterUser(userRegister);
        }
        public async Task<ResponseMsg> LoginUser(UserLogin userLogin)
        {
            return await _accountUserRepository.Login(userLogin);
        }

        public ResponseMsg RenewToken(UserRegister userRegister)
        {
            return _accountUserRepository.RenewToken(userRegister);
        }
    }
}
