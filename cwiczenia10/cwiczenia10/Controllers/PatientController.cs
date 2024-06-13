using cwiczenia10.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenia10.Models.DTOs;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IDbService _dbService;
    public PatientController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientInfo(int id)
    {
        if (!await _dbService.DoesPatientExist(id))
            return NotFound($"Patient with id - {id} does not exist.");
        
        var patientInfo = _dbService.GetPatientInfo(id);
        return Ok(patientInfo);
    }
}