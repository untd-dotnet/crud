using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(EmpAuth user)
        {
            if (await authService.RegisterUser(user)) { 
                return Ok("Registration succesful :)");
            }
            return BadRequest("Oops ..Something went wrong");
        }

        [HttpPost("login")]
        public async Task <IActionResult> Login(EmpAuth user)
        {
            if(!ModelState.IsValid)
            {
                return  BadRequest("Validation failed");
            }
            
            if (await authService.Login(user)) {
                var tokenString = authService.GenerateTokenString(user);
                /*return Ok("Logged in succesfully :)");*/
                return Ok(tokenString);
            }
            return BadRequest("Oops ..Something went wrong");

        }
    }
}
