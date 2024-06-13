using cwiczenia10.Models;
using cwiczenia10.Models.DTOs;

namespace cwiczenia10.Services;

public interface IDbService
{
    Task<bool> DoesPatientExist(int id);
    Task<bool> DoesMedicamentExist(Medicament medicament);
    Task<bool> IsMax10Medicaments(ICollection<Medicament> medicaments);
    Task<bool> IsDueDateCorrect(DateTime due, DateTime date);
    void CreatePatient(Patient patient);
    void CreatePrescription(AddPrescription addPrescription);
    Task<PatientInfo> GetPatientInfo(int id);
}