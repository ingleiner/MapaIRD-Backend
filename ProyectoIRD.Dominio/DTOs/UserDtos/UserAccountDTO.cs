using ProyectoIRD.Dominio.Enums;

namespace ProyectoIRD.Dominio.DTOs.UserDtos
{
    internal class UserAccountDTO
    {
        public string User { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public RoleType? Role { get; set; }
    }
}
