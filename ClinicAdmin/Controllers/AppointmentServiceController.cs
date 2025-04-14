using ClinicAdmin.DTO;
using ClinicAdmin.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAdmin.Controllers
{
    [Route("api/appointmentservices")]
    [ApiController]
    public class AppointmentServiceController(IAppointmentServiceService AppointmentServiceService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var AppointmentServices = await AppointmentServiceService.GetAllAppointmentServicesAsync();
            return Ok(AppointmentServices);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var AppointmentService = await AppointmentServiceService.GetAppointmentServiceByIdAsync(id);
            return Ok(AppointmentService);
        }

        [HttpGet("byAppointment/{id}")]
        public async Task<IActionResult> GetByAppointment(int id)
        {
            var AppointmentService = await AppointmentServiceService.GetAppointmentServiceByAppointmentIdAsync(id);
            return Ok(AppointmentService);
        }

        [HttpGet("byService/{id}")]
        public async Task<IActionResult> GetByService(int id)
        {
            var AppointmentService = await AppointmentServiceService.GetAppointmentServiceByServiceIdAsync(id);
            return Ok(AppointmentService);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AppointmentServiceRequest AppointmentServiceRequest)
        {
            await AppointmentServiceService.AddAppointmentServiceAsync(AppointmentServiceRequest);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AppointmentServiceRequest AppointmentServiceRequest)
        {
            await AppointmentServiceService.UpdateAppointmentServiceAsync(id, AppointmentServiceRequest);
            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await AppointmentServiceService.DeleteAppointmentServiceAsync(id);
            return NoContent();
        }
    }
}
