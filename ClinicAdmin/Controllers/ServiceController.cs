using ClinicAdmin.Services;
using Microsoft.AspNetCore.Mvc;
using ClinicAdmin.DTO;


namespace ClinicAdmin.Controllers
{
    [Route("api/services")]
    [ApiController]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Services = await _serviceService.GetAllServicesAsync();
            return Ok(Services);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Service = await _serviceService.GetServiceByIdAsync(id);
            return Ok(Service);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ServiceRequest serviceRequest)
        {
            await _serviceService.AddServiceAsync(serviceRequest);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ServiceRequest serviceRequest)
        {
            await _serviceService.UpdateServiceAsync(id, serviceRequest);
            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceService.DeleteServiceAsync(id);
            return NoContent();
        }
    }
}
