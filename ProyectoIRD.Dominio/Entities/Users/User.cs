using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Dominio.Entities.Users
{
    public class User : IdentityUser
    {
        public string DocumentType { get; set; }
        public long DocumentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobArea { get; set; }
        public string JobTitle { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<UsersRoles> UserRole { get; set; }
    }
}
