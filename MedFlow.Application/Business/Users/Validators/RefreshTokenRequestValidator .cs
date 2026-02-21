

using Application.Business.Users.Requests;
using FluentValidation;

namespace Application.Business.Users.Validators;

public sealed class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequest>
{
    public RefreshTokenRequestValidator()
    {
        RuleFor(x => x.RefreshToken).NotEmpty().MaximumLength(255);
    }
}

