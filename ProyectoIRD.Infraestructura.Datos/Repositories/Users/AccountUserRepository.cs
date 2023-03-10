using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProyectoIRD.Aplicaciones.Interfaces.IUsers;
using ProyectoIRD.Dominio.DTOs.UserDtos;
using ProyectoIRD.Dominio.Entities.Users;
using ProyectoIRD.Dominio.Interfaces.IUsers;
using ProyectoIRD.Dominio.Utils;
using System.Security.Claims;

namespace ProyectoIRD.Infraestructura.Datos.Repositories.Users
{
    public class AccountUserRepository : IAccountUserRepository
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly ResponseMsg _response;
        private readonly AutheticationResponse _responseToken;

        public AccountUserRepository(IMapper mapper, UserManager<User> userManager,
            ITokenService tokenService, SignInManager<User> signInManager,
            IUserService userService, IRoleService roleService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userService = userService;
            _roleService = roleService;
            _response = new ResponseMsg();
            _responseToken = new AutheticationResponse();
        }


        public async Task<ResponseMsg> RegisterUser(UserRegister userRegister)
        {
            try
            {
                User userDb = await _userManager.FindByEmailAsync(userRegister.Email);
                if (userDb == null)
                {
                    var user = new User
                    {
                        UserName = userRegister.Email,
                        Email = userRegister.Email,
                        FirstName = userRegister.FirstName,
                        LastName = userRegister.LastName,
                        JobArea = userRegister.JobArea,
                        JobTitle = userRegister.JobTitle,
                        CreatedAt = Utils.DateNow(),
                        UpdatedAt = Utils.DateNow()
                    };
                    var result = await _userManager.CreateAsync(user, userRegister.PasswordHash);
                    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, userRegister.RolName));
                    await _userManager.AddToRoleAsync(user, userRegister.RolName);
                    if (result.Succeeded)
                    {
                        // AutheticationResponse responseToken = _tokenService.BuildToken(userRegister);
                        _response.Message = $"El usuario {userRegister.FirstName} {userRegister.LastName} ha sido registrado exitosamente";
                        _response.Status = true;
                    }

                    if (!result.Succeeded)
                    {
                        _response.Message = result.Errors.First().Description;
                        _response.Status = false;
                    }
                }
                if (userDb != null)
                {
                    _response.Message = "Ya existe un usuario registrado con este email";
                    _response.Status = false;
                }

            }
            catch (Exception ex)
            {

                _response.Message = ex.InnerException!.ToString();
                _response.Status = false;
            }

            return _response;
        }

        public async Task<ResponseMsg> Login(UserLogin userLogin)
        {
            try
            {
                User userDb = await _userManager.FindByEmailAsync(userLogin.Email);
                if (userDb != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(userLogin.Email,
                                 userLogin.Password, isPersistent: false, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        var user = await _userManager.FindByEmailAsync(userLogin.Email);
                        IList<string> roles = await _userManager.GetRolesAsync(user);
                        AutheticationResponse responseToken = _tokenService.BuildTokenLogin(userLogin, roles);
                        UserDto userDto = await _userService.GetUserDtoByEmail(userLogin.Email);
                        userDto.RolNames = roles.ToList();
                        _response.UserDto = userDto;
                        _response.AuthResponse = responseToken;
                        _response.Status = true;
                        _response.Message = "Login Correcto";
                        //_responseToken.Token = responseToken.Token;
                        // _responseToken.Expiration = responseToken.Expiration;
                    }
                    if (!result.Succeeded)
                    {
                        _response.UserDto = null;
                        _response.AuthResponse = null;
                        _response.Status = false;
                        _response.Message = "Login Incorrecto";
                    }
                }
                if (userLogin == null)
                {
                    _response.UserDto = null;
                    _response.Message = "El usuario no se encuentra registrado";
                    _response.Status = false;
                }

            }
            catch (Exception ex)
            {
                //_responseToken.Token = null;
                _response.Message = ex.InnerException!.ToString();
            }

            return _response;
        }

        public ResponseMsg RenewToken(UserRegister userRegister)
        {
            AutheticationResponse responseToken = _tokenService.BuildToken(userRegister);
            _response.Message = "Ok";
            _response.Status = true;
            _response.AuthResponse = responseToken;
            return _response;
        }
    }
}
