using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IEmpService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> AddEmployee(AddEmployeeRequest addEmployeeRequest);
        Task<Employee> UpdateEmployee(int id, UpdateEmployeeRequest updateEmployeeRequest);
        Task<Employee> DeleteEmployee(int id);

    }
}
