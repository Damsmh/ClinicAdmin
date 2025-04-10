﻿using Microsoft.AspNetCore.Mvc;
using ClinicAdmin.Services;
using ClinicAdmin.DTO;

namespace ClinicAdmin.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patienttService)
        {
            _patientService = patienttService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PatientRequest patientRequest)
        {
            await _patientService.AddPatientAsync(patientRequest);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]PatientRequest patientRequest)
        {
            await _patientService.UpdatePatientAsync(id, patientRequest);
            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _patientService.DeletePatientAsync(id);
            return NoContent();
        }
    }
}
