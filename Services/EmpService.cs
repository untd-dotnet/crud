using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class EmpService :IEmpService   {
        
        private readonly IEmployeeRepository employeeRepository;
        public EmpService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await employeeRepository.GetEmployees(); 
        }

        public async Task<Employee> GetEmployee(int id) { 
        
            return await employeeRepository.GetEmployee(id);
        
        }

        public async Task<Employee>AddEmployee(AddEmployeeRequest addEmployeeRequest) { 
        
            return await employeeRepository.AddEmployee(addEmployeeRequest);
        
        }

        public async Task<Employee> UpdateEmployee(int id, UpdateEmployeeRequest updateEmployeeRequest) {

            return await employeeRepository.UpdateEmployee(id, updateEmployeeRequest);
        
        }


        public async Task<Employee> DeleteEmployee(int id) { 
            return await employeeRepository.DeleteEmployee(id); 
        }

    }
}

