using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Xml.Serialization;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;
namespace WebApplication1.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeesAPIDbContext dbContext;

        public EmployeeRepository(EmployeesAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await dbContext.Employees.ToListAsync();
        }


        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await dbContext.Employees.FindAsync(id);

            return employee;
        }
        public async Task<Employee> AddEmployee(AddEmployeeRequest addEmployeeRequest)
        {
            var employee = new Employee()
            {

                firstname = addEmployeeRequest.firstname,
                lastname = addEmployeeRequest.lastname,
                mobile = addEmployeeRequest.mobile,
                email = addEmployeeRequest.email,
                jobtitle = addEmployeeRequest.jobtitle

            };
            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return employee;

        }

        public async Task<Employee> UpdateEmployee(int id, UpdateEmployeeRequest updateEmployeeRequest)
        {

            var employee = await  dbContext.Employees.FindAsync(id);
            if (employee != null)
            {
                employee.id = updateEmployeeRequest.id;
                employee.firstname = updateEmployeeRequest.firstname;
                employee.lastname = updateEmployeeRequest.lastname;
                employee.mobile = updateEmployeeRequest.mobile;
                employee.email = updateEmployeeRequest.email;
                employee.jobtitle = updateEmployeeRequest.jobtitle;

                 await dbContext.SaveChangesAsync();
                
            }
            return employee;

        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var employee = await dbContext.Employees.FindAsync(id);
            if (employee != null)
            {
                dbContext.Remove(employee);
                await dbContext.SaveChangesAsync();

            }
            return employee;

        }

        



    }
}


