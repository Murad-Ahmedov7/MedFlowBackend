

using Application.Business.Examinations.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Examinations.Requests;

public record class CreateExaminationRequest:IRequest<Result<CreateExaminationResponse>>
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
