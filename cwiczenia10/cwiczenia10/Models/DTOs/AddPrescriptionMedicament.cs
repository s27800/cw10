namespace cwiczenia10.Models.DTOs;

public class AddPrescriptionMedicament
{
    public int IdMedicament { get; set; }
    public int? Dose { get; set; }
    public string Description { get; set; }
}