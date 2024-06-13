using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia10.Models;

public class Doctor
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
}