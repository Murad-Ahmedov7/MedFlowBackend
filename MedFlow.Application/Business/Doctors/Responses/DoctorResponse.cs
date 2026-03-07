
namespace Application.Business.Doctors.Responses;

public class DoctorResponse
{
    public Guid Id { get; set; }
    public Guid DepartmentId { get; set; }

    public Guid UserId { get; set; }

    public string Specialty { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }

    public DateTime CreatedAt { get; set; }
}

