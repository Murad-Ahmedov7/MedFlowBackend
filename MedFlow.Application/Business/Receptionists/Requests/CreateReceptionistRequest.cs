
using Application.Business.Receptionists.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Receptionists.Requests;

public record class CreateReceptionistRequest:IRequest<Result<CreateReceptionistResponse>>
{
    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string ConfirmPassword { get; set; } = string.Empty;
}


