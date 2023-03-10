using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProyectoIRD.Dominio.DTOs.UserDtos;
using ProyectoIRD.Dominio.Entities.Users;
using ProyectoIRD.Dominio.Interfaces.IUsers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProyectoIRD.Infraestructura.Datos.Repositories.Users
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public TokenRepository(IConfiguration configuration, UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }
        public AutheticationResponse BuildToken(UserRegister userRegister)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(creds);
            var claims = new List<Claim>()
            {
                new Claim("email", userRegister.Email),
                new Claim("role", userRegister.RolName)
            };
            var expiration = DateTime.UtcNow.AddHours(10);

            var payload = new JwtPayload
                (
                    _configuration["Authentication:Issuer"],
                    _configuration["Authentication:Audience"],
                    claims,
                    DateTime.Now,
                    expiration
                );

            var securityToken = new JwtSecurityToken(header, payload);

            return new AutheticationResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiration = expiration
            };
        }

        public AutheticationResponse BuildTokenLogin(UserLogin userLogin, IList<string> roles)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(creds);
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, userLogin.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var rol in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }
            var expiration = DateTime.UtcNow.AddDays(1);

            var payload = new JwtPayload
                (
                    _configuration["Authentication:Issuer"],
                    _configuration["Issuer:Audience"],
                    claims,
                    DateTime.Now,
                    expiration
                );

            var securityToken = new JwtSecurityToken(header, payload);

            return new AutheticationResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiration = expiration
            };
        }

    }
}
