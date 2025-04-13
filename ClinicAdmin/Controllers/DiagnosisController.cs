using ClinicAdmin.DTO;
using ClinicAdmin.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAdmin.Controllers
{
    [Route("api/diagnoses")]
    [ApiController]
    public class DiagnosisController(IDiagnosisService DiagnosisService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Diagnosiss = await DiagnosisService.GetAllDiagnosesAsync();
            return Ok(Diagnosiss);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Diagnosis = await DiagnosisService.GetDiagnosisByIdAsync(id);
            return Ok(Diagnosis);
        }

        [HttpGet("byAppointment/{id}")]
        public async Task<IActionResult> GetByAppointment(int id)
        {
            var Diagnosis = await DiagnosisService.GetDiagnosesByAppointmentIdAsync(id);
            return Ok(Diagnosis);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DiagnosisRequest DiagnosisRequest)
        {
            await DiagnosisService.AddDiagnosisAsync(DiagnosisRequest);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DiagnosisRequest DiagnosisRequest)
        {
            await DiagnosisService.UpdateDiagnosisAsync(id, DiagnosisRequest);
            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await DiagnosisService.DeleteDiagnosisAsync(id);
            return NoContent();
        }
    }
}
