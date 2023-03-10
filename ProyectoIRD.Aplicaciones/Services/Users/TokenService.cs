using ProyectoIRD.Aplicaciones.Interfaces.IUsers;
using ProyectoIRD.Dominio.DTOs.UserDtos;
using ProyectoIRD.Dominio.Interfaces.IUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Aplicaciones.Services.Users
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;

        public TokenService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }
        public AutheticationResponse BuildToken(UserRegister userLogin)
        {
            return _tokenRepository.BuildToken(userLogin);
        }

        public AutheticationResponse BuildTokenLogin(UserLogin userLogin, IList<string> roles)
        {
            return _tokenRepository.BuildTokenLogin(userLogin, roles);
        }
    }
}
