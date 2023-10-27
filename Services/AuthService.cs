using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class AuthService : IAuthService
    {
        private UserManager<IdentityUser> userManager;
        private readonly IConfiguration config;

        public AuthService(UserManager<IdentityUser> userManager,IConfiguration config)
        {
            this.userManager = userManager;
            this.config = config;
        }
        public async Task<bool> RegisterUser(EmpAuth user)
        {
            var identityUser = new IdentityUser
            {
                UserName = user.email,
                Email = user.email

            };
            var result = await userManager.CreateAsync(identityUser, user.password);
            return result.Succeeded;

        }

        public async Task<bool>Login(EmpAuth user)
        {
            var identityUser =await userManager.FindByEmailAsync(user.email);
            if (identityUser == null)
            {
                return false;
            }
           return await userManager.CheckPasswordAsync(identityUser, user.password);

        }

        public string GenerateTokenString(EmpAuth user)
        {
            var claims = new List<Claim> {
            
                new Claim(ClaimTypes.Role,"Admin")
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("Jwt:Key").Value));
            SigningCredentials SigningCreds = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature);
            var jwtSecurityToken = new JwtSecurityToken(
                claims:claims,
                expires:DateTime.Now.AddSeconds(720),
                issuer:config.GetSection("Jwt:Issuer").Value,
                audience:config.GetSection("Jwt:Audience").Value,
                signingCredentials:SigningCreds
                );
          string tokenString = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return tokenString;
        }
    }
}
