using cwiczenia10.Models;
using cwiczenia10.Models.DTOs;
using cwiczenia10.Services;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenia10.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private readonly IDbService _dbService;
    public PrescriptionController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> AddNewPrescription(AddPrescription addPrescription)
    {
        if (!await _dbService.DoesPatientExist(addPrescription.Patient.IdPatient))
            _dbService.CreatePatient(addPrescription.Patient);

        if (addPrescription.Medicaments.Count > 10)
            return BadRequest("Max number of medicaments is 10.");
        
        for (int i = 0; i < addPrescription.Medicaments.Count; i++)
        {
            if (!await _dbService.DoesMedicamentExist(addPrescription.Medicaments.ElementAt(i).IdMedicament))
                return NotFound($"Medicament with id - {addPrescription.Medicaments.ElementAt(i).IdMedicament} does not exist.");
        }
        
        if (addPrescription.DueDate < addPrescription.Date)
            return BadRequest("Due date must be after date.");

        _dbService.CreatePrescription(addPrescription);

        return Created();
    }
    
}