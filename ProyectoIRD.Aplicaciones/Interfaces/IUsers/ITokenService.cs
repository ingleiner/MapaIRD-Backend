using ProyectoIRD.Dominio.DTOs.UserDtos;

namespace ProyectoIRD.Aplicaciones.Interfaces.IUsers
{
    public interface ITokenService
    {
        public AutheticationResponse BuildToken(UserRegister userLogin);
        public AutheticationResponse BuildTokenLogin(UserLogin userLogin, IList<string> roles);
    }
}
