using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AuthAPIDbContext :IdentityDbContext
    {
        public AuthAPIDbContext(DbContextOptions<AuthAPIDbContext> options) :base(options) 
        {
        }
        public DbSet<EmpAuth> EmpAuths { get; set; }
    }
}
 