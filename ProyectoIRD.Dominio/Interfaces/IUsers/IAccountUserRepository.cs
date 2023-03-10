using ProyectoIRD.Dominio.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Dominio.Interfaces.IUsers
{
    public interface IAccountUserRepository
    {
        Task<ResponseMsg> RegisterUser(UserRegister userRegister);

        Task<ResponseMsg> Login(UserLogin userLogin);
        ResponseMsg RenewToken(UserRegister userRegister);

    }
}
