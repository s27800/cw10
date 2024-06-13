using cwiczenia10.Models;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia10.Context;

public class ApbdContext : DbContext
{
    protected ApbdContext()
    {
    }

    protected ApbdContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Doctor>(e =>
        {
            e.ToTable("Doctor");

            e.HasKey(e => e.IdDoctor);
            e.Property(e => e.FirstName).HasMaxLength(100);
            e.Property(e => e.LastName).HasMaxLength(100);
            e.Property(e => e.Email).HasMaxLength(100);
            
            e.HasData(new List<Doctor>()
            {
                new() { IdDoctor = 1, FirstName = "Fname", LastName = "Lname", Email = "kowalski@gmail.com"},
                new() { IdDoctor = 2, FirstName = "Firstname", LastName = "Lastname", Email = "nowak@gmail.com"},
            });
        });
        
        modelBuilder.Entity<Medicament>(e =>
        {
            e.ToTable("Medicament");

            e.HasKey(e => e.IdMedicament);
            e.Property(e => e.Name).HasMaxLength(100);
            e.Property(e => e.Description).HasMaxLength(100);
            e.Property(e => e.Type).HasMaxLength(100);
            
            e.HasData(new List<Medicament>()
            {
                new() { IdMedicament = 1, Name = "Apap", Description = "for headache", Type = "type"},
                new() { IdMedicament = 2, Name = "Ibuprom", Description = "for headache", Type = "type"},
            });
        });
        
        modelBuilder.Entity<Patient>(e =>
        {
            e.ToTable("Patient");

            e.HasKey(e => e.IdPatient);
            e.Property(e => e.FirstName).HasMaxLength(100);
            e.Property(e => e.LastName).HasMaxLength(100);
            
            e.HasData(new List<Patient>()
            {
                new() { IdPatient = 1, FirstName = "Jan", LastName = "Kowalski", Birthdate = DateTime.Parse("2003-02-20")},
                new() { IdPatient = 2, FirstName = "Andrzej", LastName = "Kowalski", Birthdate = DateTime.Parse("1984-05-21")},
            });
        });
        
        modelBuilder.Entity<Prescription>(e =>
        {
            e.ToTable("Prescription");

            e.HasKey(e => e.IdPrescription);
            
            e.HasOne(e => e.Doctor)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.IdDoctor)
                .OnDelete(DeleteBehavior.Cascade);
            
            e.HasOne(e => e.Patient)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.IdPatient)
                .OnDelete(DeleteBehavior.Cascade);
            
            e.HasData(new List<Prescription>()
            {
                new() { IdPrescription = 1, Date = DateTime.Parse("2024-05-24"), DueDate = DateTime.Parse("2024-10-30"), IdPatient = 1, IdDoctor = 2},
                new() { IdPrescription = 2, Date = DateTime.Parse("2024-05-20"), DueDate = DateTime.Parse("2024-10-20"), IdPatient = 2, IdDoctor = 1},
            });
        });
        
        modelBuilder.Entity<PrescriptionMedicament>(e =>
        {
            e.ToTable("Prescription_Medicament");

            e.HasKey(e => new { e.IdMedicament, e.IdPrescription});
            e.Property(e => e.Details).HasMaxLength(100);
            
            e.HasOne(e => e.Medicament)
                .WithMany(e => e.PrescriptionMedicaments)
                .HasForeignKey(e => e.IdMedicament)
                .OnDelete(DeleteBehavior.Cascade);
            
            e.HasOne(e => e.Prescription)
                .WithMany(e => e.PrescriptionMedicaments)
                .HasForeignKey(e => e.IdPrescription)
                .OnDelete(DeleteBehavior.Cascade);
            
            e.HasData(new List<PrescriptionMedicament>()
            {
                new() { IdMedicament = 1, IdPrescription = 1, Dose = 3, Details = "3 times a day"},
                new() { IdMedicament = 2, IdPrescription = 2, Dose = 2, Details = "2 times a day"},
            });
        });
    }
}