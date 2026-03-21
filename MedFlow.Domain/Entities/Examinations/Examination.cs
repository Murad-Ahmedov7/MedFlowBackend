

using Domain.Entities.Appointments;
using Domain.Entities.Base;
using Domain.Entities.Prescriptions;


namespace Domain.Entities.Examinations;

public class Examination : BaseEntity
{
    public Guid AppointmentId { get; set; }

    public string Complaint { get; set; } = null!;

    public string Diagnosis {  get; set; } = null!;

    public string? Notes {  get; set; }

    public decimal Temperature { get; set; }

    public int BloodPressureSystolic { get; set; }

    public int BloodPressureDiastolic { get; set; }

    public int? Pulse { get; set; }

    public decimal? Weight { get; set; }

    public decimal? Height { get; set; }

    public Appointment Appointment { get; set; } = null!;

    public Prescription? Prescription { get; set; } 
}

