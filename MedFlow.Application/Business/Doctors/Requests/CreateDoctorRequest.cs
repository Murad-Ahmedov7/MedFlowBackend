using Application.Business.Doctors.Responses;
using Domain.ResponseModel;
using MediatR;


namespace Application.Business.Doctors.Requests;

public record class CreateDoctorRequest : IRequest<Result<DoctorResponse>>
{
    public Guid DepartmentId { get; set; }

    public Guid UserId { get; set; }

    public string Specialty { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }
}

