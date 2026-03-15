

namespace Application.Business.Examinations.Responses;

public class GetExaminationByIdResponse
{
    public Guid AppointmentId { get; set; }

    public string Complaint { get; set; } = string.Empty;

    public string Diagnosis { get; set; } = string.Empty;

    public string? Notes { get; set; }

    public decimal Temperature { get; set; }

    public int BloodPressureSystolic { get; set; }

    public int BloodPressureDiastolic { get; set; }

    public int? Pulse { get; set; }

    public decimal? Weight { get; set; }

    public decimal? Height { get; set; }
}

