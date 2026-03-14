
using Application.Business.Appointments.Requests;
using FluentValidation;

namespace Application.Business.Appointments.Validators;

public sealed class CreateAppointmentRequestValidator : AbstractValidator<CreateAppointmentRequest>
{
    public CreateAppointmentRequestValidator()
    {
        RuleFor(x => x.PatientId)
            .NotEmpty();
        RuleFor(x => x.DoctorId)
            .NotEmpty();

        RuleFor(x => x.AppointmentDate)
            .NotEmpty()
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow));

        RuleFor(x => x.StartTime)
            .NotEmpty();

        RuleFor(x => x.EndTime)
            .NotEmpty()
            .GreaterThan(x => x.StartTime)
            .WithMessage("EndTime must be greater than StartTime");

        RuleFor(x => x.AppointmentType)
            .NotEmpty()
            .InclusiveBetween((byte)1, (byte)2);

        RuleFor(x => x.Status)
            .NotEmpty()
            .InclusiveBetween( (byte)1,(byte)3);
    }
}

