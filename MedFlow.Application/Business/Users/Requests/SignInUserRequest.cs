
using Application.Business.Users.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Users.Requests;

public record class SignInUserRequest : IRequest<Result<SignInUserResponse>>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

    