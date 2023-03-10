using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProyectoIRD.Dominio.DTOs.UserDtos;
using ProyectoIRD.Dominio.Entities.Users;
using ProyectoIRD.Dominio.Interfaces.IUsers;
using ProyectoIRD.Infraestructura.Datos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIRD.Infraestructura.Datos.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly MapaIRDContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        private readonly ResponseMsg _response;
        public UserRepository(MapaIRDContext context,
                                UserManager<User> userManager,
                                RoleManager<Role> roleManager,
                                IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _response = new ResponseMsg();
        }

        public async Task<User> getUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<User> getUsuariobyId(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<UserDto> GetUserDtoByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;

        }

        public async Task<IList<string>> GetUserRoles(User user)
        {
            return await _userManager.GetRolesAsync(user);
        }
    }
}
