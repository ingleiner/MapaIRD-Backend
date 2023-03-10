﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Dominio.Entities.Users
{
    public class Role : IdentityRole
    {
        public ICollection<UsersRoles> UserRole { get; set; }
    }
}
