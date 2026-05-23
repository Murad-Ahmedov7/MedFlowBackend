
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Users.Requests;

public record class ChangePasswordRequest : IRequest<Result>
{
    public string CurrentPassword { get; set; } = string.Empty;

    public string NewPassword { get; set; } = string.Empty;
}
