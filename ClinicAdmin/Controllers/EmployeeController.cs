using ClinicAdmin.DTO;
using ClinicAdmin.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAdmin.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController(IEmployeeService EmployeeService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Employees = await EmployeeService.GetAllEmployeesAsync();
            return Ok(Employees);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Employee = await EmployeeService.GetEmployeeByIdAsync(id);
            return Ok(Employee);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeRequest EmployeeRequest)
        {
            await EmployeeService.AddEmployeeAsync(EmployeeRequest);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeRequest EmployeeRequest)
        {
            await EmployeeService.UpdateEmployeeAsync(id, EmployeeRequest);
            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await EmployeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}
