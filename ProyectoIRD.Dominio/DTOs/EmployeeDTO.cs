using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Dominio.DTOs
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; } 
        public long IdentityCard { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PersonalPhone { get; set; }
        public string WorkPhone { get; set; }
        public string JobTitle { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
