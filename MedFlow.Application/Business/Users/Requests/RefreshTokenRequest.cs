using Application.Business.Users.Responses;
using Domain.ResponseModel;
using MediatR;


public record class RefreshTokenRequest : IRequest<Result<LoginUserResponse>>
{
    public string RefreshToken { get; set; } = string.Empty;
}

