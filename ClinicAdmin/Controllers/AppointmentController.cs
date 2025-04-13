using ClinicAdmin.DTO;
using ClinicAdmin.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAdmin.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentController(IAppointmentService AppointmentService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Appointments = await AppointmentService.GetAllAppointmentsAsync();
            return Ok(Appointments);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Appointment = await AppointmentService.GetAppointmentByIdAsync(id);
            return Ok(Appointment);
        }

        [HttpGet("byPatient/{id}")]
        public async Task<IActionResult> GetByPatient(int id)
        {
            var Appointment = await AppointmentService.GetAppointmentByPatientIdAsync(id);
            return Ok(Appointment);
        }

        [HttpGet("byEmployee/{id}")]
        public async Task<IActionResult> GetByEmployee(int id)
        {
            var Appointment = await AppointmentService.GetAppointmentByEmployeeIdAsync(id);
            return Ok(Appointment);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AppointmentRequest AppointmentRequest)
        {
            await AppointmentService.AddAppointmentAsync(AppointmentRequest);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AppointmentRequest AppointmentRequest)
        {
            await AppointmentService.UpdateAppointmentAsync(id, AppointmentRequest);
            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await AppointmentService.DeleteAppointmentAsync(id);
            return NoContent();
        }
    }
}
