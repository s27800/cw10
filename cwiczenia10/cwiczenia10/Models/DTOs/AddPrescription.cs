namespace cwiczenia10.Models.DTOs;

public class AddPrescription
{
    public Patient Patient { get; set; } = null!;
    public ICollection<Medicament> Medicaments { get; set; } = new HashSet<Medicament>();
    public DateTime Date { get; set; }
    public DateTime? DueDate { get; set; }
}