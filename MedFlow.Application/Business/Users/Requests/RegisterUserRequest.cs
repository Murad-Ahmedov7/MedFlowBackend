using Application.Business.Users.Responses;
using Domain.Entities.Auth.Enums;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Users.Requests;

public record class RegisterUserRequest : IRequest<Result<RegisterUserResponse>>
{
    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public UserRoles UserRole { get; set; }

    public string Password { get; set; } = string.Empty;

    public string ConfirmPassword { get; set; } = string.Empty;

}
