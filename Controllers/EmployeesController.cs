using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmployeesController : Controller
    {
        private readonly IEmpService empService;

        public EmployeesController(IEmpService empService)
        {
            this.empService = empService;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await empService.GetEmployees());
        }
        [HttpGet]
        [Route("{id:int}")]
        
        public async Task<IActionResult> GetEmployee([FromRoute] int id) {
           
            return Ok(await empService.GetEmployee(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeRequest addEmployeeRequest) {

            return Ok(await empService.AddEmployee(addEmployeeRequest));
                
        }
        

        /*[HttpPost]
        public async Task<IActionResult> AddAlLContacts([FromBody] List<Person> people)
        {
        }*/

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, UpdateEmployeeRequest updateEmployeeRequest) {

            var res = empService.UpdateEmployee(id, updateEmployeeRequest);
            if (res != null) { 
                return Ok(res);
            }
            return NotFound();
            
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int  id) {

            var employee = await empService.DeleteEmployee(id);  
           
            if(employee != null)
            { 
                return Ok(employee);
            }
            return NotFound();
        }
    }
}
