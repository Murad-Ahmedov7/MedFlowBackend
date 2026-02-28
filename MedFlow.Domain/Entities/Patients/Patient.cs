using Domain.Entities.Base;
using Domain.Entities.Patients.Enums;

namespace Domain.Entities.Patients;

public class Patient:BaseEntity
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Fin { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Address { get; set; }
    public DateTime  BirthDate { get; set; }

    public Gender Gender { get; set; }

    public BloodGroup BloodGroup { get; set; }

    public string? Allergies { get; set; }
}

