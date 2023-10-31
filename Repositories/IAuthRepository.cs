using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IAuthRepository
    {
        public Task<bool> RegisterUser(EmpAuth user);
        public Task<bool> Login(EmpAuth user);
        public string GenerateTokenString(EmpAuth user);
    }
}
