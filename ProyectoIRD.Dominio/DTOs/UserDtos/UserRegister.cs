using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Dominio.DTOs.UserDtos
{
    public class UserRegister
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        //public string DocumentType { get; set; }
        //public long DocumentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobArea { get; set; }
        public string JobTitle { get; set; }
        public string RolName { get; set; }
    }
}
