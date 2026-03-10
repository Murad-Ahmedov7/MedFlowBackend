
using Application.Business.DoctorSchedules.Requests;
using Azure;
using FluentValidation;

namespace Application.Business.DoctorSchedules.Validators;

public sealed class CreateDoctorSchedulesRequestValidator : AbstractValidator<CreateDoctorSchedulesReqeust>
{
    public CreateDoctorSchedulesRequestValidator()
    {

        RuleFor(x => x.Schedules)
            .NotEmpty();

        RuleFor(x => x.Schedules)
            .Must(schedules => !schedules
                .GroupBy(s => s.DayOfWeek)
                .Any(g => g.Count() > 1))
            .WithMessage("Duplicate DayOfWeek is not allowed.");

        RuleForEach(x => x.Schedules).ChildRules(schedule =>
        {
            schedule.RuleFor(s => s.DayOfWeek)
               .NotEmpty()
               .InclusiveBetween((byte)1, (byte)7);

            schedule.RuleFor(s => s.StartTime)
                .NotEmpty();

            schedule.RuleFor(s => s.EndTime)
                .NotEmpty();

            schedule.RuleFor(s => s.EndTime)
                .GreaterThan(s => s.StartTime)
                 .WithMessage("EndTime must be greater than StartTime");

        });

    }
}
