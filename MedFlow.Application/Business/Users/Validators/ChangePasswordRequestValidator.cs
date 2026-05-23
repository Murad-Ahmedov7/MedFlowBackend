
namespace Application.Business.Users.Validators;

using Application.Business.Users.Requests;
using FluentValidation;
public sealed class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
{
    public ChangePasswordRequestValidator()
    {
        RuleFor(x => x.CurrentPassword)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(255);

        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(255)
            .NotEqual(x => x.CurrentPassword)
            .WithMessage("New password cannot be the same as current password.");
    }
}

