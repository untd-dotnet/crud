using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IAuthService
    {
        Task<string> GenerateTokenString(EmpAuth user);
        Task<bool> Login(EmpAuth user);
        Task<bool> RegisterUser(EmpAuth user);
    }
}