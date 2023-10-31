using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }

        public async Task<bool> RegisterUser(EmpAuth user)
        {
           return await authRepository.RegisterUser(user);

        }

        public async Task<bool>Login(EmpAuth user)
        {
           return await authRepository.Login(user);
        }

        public async Task<string> GenerateTokenString(EmpAuth user)
        {
            return authRepository.GenerateTokenString(user);
        }
    }
}
