using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmployeesController : Controller
    {
        private readonly EmployeesAPIDbContext dbContext;
        public EmployeesController(EmployeesAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await dbContext.Employees.ToListAsync());
        }
        [HttpGet]
        [Route("{id:int}")]
        
        public async Task<IActionResult> GetEmployee([FromRoute] int id) {
            var employee = await dbContext.Employees.FindAsync(id);
            /*if (employee == null) { 
                return NotFound();
            }*/
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeRequest addEmployeeRequest) {

            var employee = new Employee() {
                   
                firstname = addEmployeeRequest.firstname,   
                lastname = addEmployeeRequest.lastname,
                mobile = addEmployeeRequest.mobile,
                email = addEmployeeRequest.email,
                jobtitle = addEmployeeRequest.jobtitle
            
            };
            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return Ok(employee);
                
        }
        [HttpGet("greet")]
        public IActionResult greet()
        {
            return Ok("Hello");
        }

        /*[HttpPost]
        public async Task<IActionResult> AddAlLContacts([FromBody] List<Person> people)
        {
        }*/

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, UpdateEmployeeRequest updateEmployeeRequest) {
            var employee = await dbContext.Employees.FindAsync(id);
            if(employee != null)
            {
                employee.id = updateEmployeeRequest.id;  
                employee.firstname = updateEmployeeRequest.firstname;
                employee.lastname = updateEmployeeRequest.lastname;
                employee.mobile = updateEmployeeRequest.mobile;
                employee.email = updateEmployeeRequest.email;
                employee.jobtitle = updateEmployeeRequest.jobtitle;

                await dbContext.SaveChangesAsync();
                return Ok(employee);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int  id) {
            var employee = await dbContext.Employees.FindAsync(id);
            if(employee != null)
            {
                dbContext.Remove(employee);
                await dbContext.SaveChangesAsync();
                return Ok(employee);

            }
            return NotFound();
        }
    }
}
