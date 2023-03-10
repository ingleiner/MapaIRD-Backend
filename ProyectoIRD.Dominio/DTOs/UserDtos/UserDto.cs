using ProyectoIRD.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Dominio.DTOs.UserDtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobArea { get; set; }
        public string JobTitle { get; set; }
        public List<string> RolNames { get; set; }
    }
}
