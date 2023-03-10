using ProyectoIRD.Dominio.DTOs.UserDtos;
using ProyectoIRD.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Dominio.Interfaces.IUsers
{
    public interface ITokenRepository
    {
        AutheticationResponse BuildToken(UserRegister userRegister);
        AutheticationResponse BuildTokenLogin(UserLogin userLogin, IList<string> roles);
    }
}
