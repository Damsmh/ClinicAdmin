using ClinicAdmin.DTO;
using ClinicAdmin.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAdmin.Controllers
{
    [Route("api/medications")]
    [ApiController]
    public class MedicationController(IMedicationService MedicationService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Medications = await MedicationService.GetAllMedicationsAsync();
            return Ok(Medications);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Medication = await MedicationService.GetMedicationByIdAsync(id);
            return Ok(Medication);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MedicationRequest MedicationRequest)
        {
            await MedicationService.AddMedicationAsync(MedicationRequest);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MedicationRequest MedicationRequest)
        {
            await MedicationService.UpdateMedicationAsync(id, MedicationRequest);
            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await MedicationService.DeleteMedicationAsync(id);
            return NoContent();
        }
    }
}
