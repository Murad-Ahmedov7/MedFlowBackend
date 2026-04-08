
using Application.Business.Users.Requests;
using Domain.Entities.Auth.Enums;
using FluentValidation;

namespace Application.Business.Users.Validators;

public sealed class SignUpUserRequestValidator : AbstractValidator<SignUpUserRequest>
{
    public SignUpUserRequestValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(255);

        RuleFor(x => x.Phone)
            .NotEmpty()
            .MaximumLength(20)
            .Must(p => p.Count(char.IsDigit) >= 9 && p.Count(char.IsDigit) <= 15)
            .Matches(@"^[0-9+\-\s()]+$");

        RuleFor(x => x.UserRole)
            .NotEmpty().WithMessage("Role is required")
            .Must(role => Enum.TryParse<UserRole>(role, true, out _))
            .WithMessage("Invalid role");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(255);

        RuleFor(x => x)
            .Must(x => x.Password == x.ConfirmPassword)
            .WithMessage("Passwords do not match.");
    }
}

