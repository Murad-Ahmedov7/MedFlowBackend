
using Application.Business.Appointments.Requests;
using FluentValidation;


namespace Application.Business.Appointments.Validators;

public sealed class UpdateAppointmentStatusRequestValidator : AbstractValidator<UpdateAppointmentStatusRequest>
{
    public UpdateAppointmentStatusRequestValidator()
    {
        RuleFor(x => x.Status)
            .NotEmpty()
            .InclusiveBetween((byte)1, (byte)3);
    }
}

