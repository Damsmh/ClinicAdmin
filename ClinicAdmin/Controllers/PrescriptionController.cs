using ClinicAdmin.DTO;
using ClinicAdmin.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAdmin.Controllers
{
    [Route("api/prescriptions")]
    [ApiController]
    public class PrescriptionController(IPrescriptionService PrescriptionService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Prescriptions = await PrescriptionService.GetAllPrescriptionsAsync();
            return Ok(Prescriptions);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Prescription = await PrescriptionService.GetPrescriptionByIdAsync(id);
            return Ok(Prescription);
        }

        [HttpGet("byDiagnosis/{id}")]
        public async Task<IActionResult> GetByDiagnosis(int id)
        {
            var Prescription = await PrescriptionService.GetPrescriptionByDiagnosisIdAsync(id);
            return Ok(Prescription);
        }

        [HttpGet("byMedication/{id}")]
        public async Task<IActionResult> GetByMedication(int id)
        {
            var Prescription = await PrescriptionService.GetPrescriptionByMedicationIdAsync(id);
            return Ok(Prescription);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PrescriptionRequest PrescriptionRequest)
        {
            await PrescriptionService.AddPrescriptionAsync(PrescriptionRequest);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PrescriptionRequest PrescriptionRequest)
        {
            await PrescriptionService.UpdatePrescriptionAsync(id, PrescriptionRequest);
            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await PrescriptionService.DeletePrescriptionAsync(id);
            return NoContent();
        }
    }
}
