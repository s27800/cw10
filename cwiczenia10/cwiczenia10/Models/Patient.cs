using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia10.Models;

public class Patient
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    
    public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
}