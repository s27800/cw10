using cwiczenia10.Models;
using cwiczenia10.Models.DTOs;

namespace cwiczenia10.Services;

public interface IDbService
{
    Task<bool> DoesPatientExist(int id);
    Task<bool> DoesMedicamentExist(int id);
    Task CreatePatient(Patient patient);
    Task CreatePrescription(AddPrescription addPrescription);
    Task<ICollection<Patient>> GetPatientInfo(int id);
}