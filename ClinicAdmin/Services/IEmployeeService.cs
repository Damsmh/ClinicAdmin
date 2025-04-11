using ClinicAdmin.DTO;

namespace ClinicAdmin.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResponse>> GetAllEmployeesAsync();
        Task<EmployeeResponse> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(EmployeeRequest employeeRequest);
        Task UpdateEmployeeAsync(int id, EmployeeRequest employeeRequest);
        Task DeleteEmployeeAsync(int id);
    }
}
