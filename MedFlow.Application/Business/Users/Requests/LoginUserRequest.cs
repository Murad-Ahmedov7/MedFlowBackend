
using Application.Business.Users.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Users.Requests;

public record class LoginUserRequest : IRequest<Result<LoginUserResponse>>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

    