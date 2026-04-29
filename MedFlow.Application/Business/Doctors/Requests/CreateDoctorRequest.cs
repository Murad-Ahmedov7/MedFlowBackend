
using Application.Business.Doctors.Responses;
using Domain.ResponseModel;
using MediatR;


namespace Application.Business.Doctors.Requests;


public record class CreateDoctorRequest : IRequest<Result<CreateDoctorResponse>>
{
    // AUTH
    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string ConfirmPassword { get; set; } = string.Empty;


    // DOCTOR
    public Guid DepartmentId { get; set; }

    public string Specialty { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }
}
