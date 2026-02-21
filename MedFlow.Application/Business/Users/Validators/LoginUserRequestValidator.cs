using Application.Business.Users.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Business.Users.Validators;
public sealed class LoginUserRequestValidator:AbstractValidator<LoginUserRequest>
{
    public LoginUserRequestValidator()
    {
        RuleFor(x=>x.Email).NotEmpty().EmailAddress().MaximumLength(255);
        RuleFor(x=>x.Password).NotEmpty().MinimumLength(8).MaximumLength(255);
    }
}

