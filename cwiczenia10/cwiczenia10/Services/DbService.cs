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

    public async Task CreatePatient(Patient patient)
    {
        await _context.AddAsync(patient);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DoesMedicamentExist(int id)
    {
        return await _context.Medicaments.AnyAsync(e => e.IdMedicament == id);
    }

    public async Task CreatePrescription(AddPrescription addPrescription)
    {
        int id = _context.Prescriptions.Max(e => e.IdPrescription) + 1;
        var prescription = new Prescription()
        {
            IdPrescription = id, 
            Date = addPrescription.Date,
            DueDate = addPrescription.DueDate.GetValueOrDefault(),
            IdPatient = addPrescription.Patient.IdPatient,
            IdDoctor = 0
        };
        await _context.AddAsync(prescription);

        foreach (var medicament in addPrescription.Medicaments)
        {
            var med = new PrescriptionMedicament()
            {
                IdMedicament = medicament.IdMedicament,
                IdPrescription = id,
                Dose = medicament.Dose,
                Details = medicament.Description
            };
            await _context.AddAsync(med);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Patient>> GetPatientInfo(int id)
    {

        return await _context.Patients
            .Include(e => e.Prescriptions)
            .ThenInclude(e => e.PrescriptionMedicaments)
            .ThenInclude(e => e.Prescription.Doctor)
            .Where(e => e.IdPatient == id)
            .ToListAsync();
    }
}