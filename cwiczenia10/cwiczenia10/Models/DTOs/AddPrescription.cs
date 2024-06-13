namespace cwiczenia10.Models.DTOs;

public class AddPrescription
{
    public Patient Patient { get; set; } = null!;
    public ICollection<AddPrescriptionMedicament> Medicaments { get; set; } = new HashSet<AddPrescriptionMedicament>();
    public DateTime Date { get; set; }
    public DateTime? DueDate { get; set; }
}