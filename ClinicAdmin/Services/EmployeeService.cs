using AutoMapper;
using ClinicAdmin.DTO;
using ClinicAdmin.Entities;
using ClinicAdmin.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAdmin.Services
{
    public class EmployeeService(IEmployeeRepository repository, IMapper mapper) : IEmployeeService
    {
        public async Task<IEnumerable<EmployeeResponse>> GetAllEmployeesAsync()
        {
            var Employees = await repository.GetAllAsync();
            var EmployeeResponse = mapper.Map<IEnumerable<EmployeeResponse>>(Employees);
            return EmployeeResponse;
        }

        public async Task<EmployeeResponse> GetEmployeeByIdAsync([FromQuery] int id)
        {
            var Employee = await repository.GetByIdAsync(id);
            if (Employee == null)
                throw new KeyNotFoundException("Employee not found");
            var EmployeeResponse = mapper.Map<EmployeeResponse>(Employee);

            return EmployeeResponse;
        }
        public async Task AddEmployeeAsync([FromBody] EmployeeRequest EmployeeRequest)
        {
            var Employee = mapper.Map<Employee>(EmployeeRequest);
            await repository.AddAsync(Employee);
        }


        public async Task UpdateEmployeeAsync([FromQuery] int id, [FromBody] EmployeeRequest EmployeeRequest)
        {
            var Employee = await repository.GetByIdAsync(id);
            if (Employee == null)
                throw new KeyNotFoundException("Employee not found");
            Employee = mapper.Map<Employee>(EmployeeRequest);
            Employee.EmployeeId = id;
            await repository.UpdateAsync(Employee);
        }


        public async Task DeleteEmployeeAsync([FromQuery] int id)
        {
            var Employee = await repository.GetByIdAsync(id);


            if (Employee == null)
                throw new KeyNotFoundException("Employee not found");


            await repository.DeleteAsync(id);
        }
    }
}
