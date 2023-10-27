using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
namespace WebApplication1.Data
{
    public class EmployeesAPIDbContext : DbContext
    {
        public EmployeesAPIDbContext(DbContextOptions<EmployeesAPIDbContext> options) : base(options)
        {

        }
        public DbSet<Employee>Employees{ get; set; }
    }
}
