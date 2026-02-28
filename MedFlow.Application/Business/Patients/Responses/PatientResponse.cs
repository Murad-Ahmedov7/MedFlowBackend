

namespace Application.Business.Patients.Responses;

public class PatientResponse
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Fin { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string? Address { get; set; }

    public DateTime BirthDate { get; set; }

    public string Gender { get; set; } = string.Empty;

    public string BloodGroup { get; set; } = string.Empty;

    public string? Allergies { get; set; }

    public DateTime CreatedAt { get; set; }
}

