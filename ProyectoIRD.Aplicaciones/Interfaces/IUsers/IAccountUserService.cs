using ProyectoIRD.Dominio.DTOs.UserDtos;

namespace ProyectoIRD.Aplicaciones.Interfaces.IUsers
{
    /// <summary>
    /// Interfaz que define las reglas de negocio sobre la autenticación de un
    /// Usuario el aplicación
    /// </summary>
    public interface IAccountUserService
    {
        public Task<ResponseMsg> RegisterUser(UserRegister userRegister);
        public Task<ResponseMsg> LoginUser(UserLogin userLogin);
        public ResponseMsg RenewToken(UserRegister userRegister);
    }
}
