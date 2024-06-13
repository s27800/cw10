using cwiczenia10.Context;
using cwiczenia10.Models;
using cwiczenia10.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia10.Services;

public class DbService : IDbService
{
    private readonly ApbdContext _context;

    public DbService(ApbdContext context)
    {
        _context = context;
    }

    public async Task<bool> DoesPatientExist(int id)
    {
        return await _context.Patients.AnyAsync(e => e.IdPatient == id);
    }

    public async void CreatePatient(Patient patient)
    {
        
    }

    public async Task<bool> DoesMedicamentExist(Medicament medicament)
    {
        return true;
    }

    public async Task<bool> IsMax10Medicaments(ICollection<Medicament> medicaments)
    {
        return true;
    }

    public async Task<bool> IsDueDateCorrect(DateTime due, DateTime date)
    {
        return true;
    }

    public async void CreatePrescription(AddPrescription addPrescription)
    {
        
    }

    public async Task<PatientInfo> GetPatientInfo(int id)
    {

        return new PatientInfo();
    }
}