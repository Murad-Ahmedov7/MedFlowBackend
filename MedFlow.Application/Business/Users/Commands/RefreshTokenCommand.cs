
using Application.Business.Users.Responses;
using Application.Infrastructure;
using DataAccess.Core;
using Domain.Entities.Auth;
using Domain.ResponseModel;
namespace Application.Business.Users.Commands;


internal sealed class RefreshTokenCommand : SysRequestHandler<RefreshTokenRequest, Result<SignInUserResponse>>
{

    private readonly ITokenProvider _tokenProvider;
    private readonly SqlUnitOfWork _sqlUnitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public RefreshTokenCommand(ITokenProvider tokenProvider, SqlUnitOfWork sqlUnitOfWork, ICurrentUserService currentUserService)
        : base(currentUserService)
    {
        _tokenProvider = tokenProvider;
        _sqlUnitOfWork = sqlUnitOfWork;
        _currentUserService = currentUserService;
    }

    public override async Task<Result<SignInUserResponse>> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        var tokenResult = await _sqlUnitOfWork.AuthRepository.GetByTokenAsync(request.RefreshToken, cancellationToken);

        if (tokenResult is null || tokenResult.ExpiresOnUtc < DateTime.UtcNow || tokenResult.AbsoluteExpiresOnUtc < DateTime.UtcNow)
        {
            return new Result<SignInUserResponse>(["Invalid or expired refresh token."]);

        }

        _sqlUnitOfWork.AuthRepository.Delete(tokenResult);

        var accessToken = _tokenProvider.GenerateAccessToken(tokenResult.User);
        var refreshToken = _tokenProvider.GenerateRefreshToken();

        _sqlUnitOfWork.AuthRepository.Add(new RefreshToken
        {
            UserId = tokenResult.UserId,
            Token = refreshToken,
            ExpiresOnUtc = DateTime.UtcNow.AddDays(7), // Refresh token expires in 7 
            AbsoluteExpiresOnUtc = tokenResult.AbsoluteExpiresOnUtc // Absolute expiration remains the same
        });

        await _sqlUnitOfWork.SaveChangesAsync();

        var response = new SignInUserResponse
        {
            Token = accessToken,
            RefreshToken = refreshToken
        };

        return new Result<SignInUserResponse>
        {
            Data = response
        };

        //Əgər refresh token ilə bağlı hər şey düzgündürsə, onu istifadə edib köhnəni silir və yenisini yaradırıq.Əgər hər hansı bir problem varsa, xəta mesajı qaytarırıq.

        //If everything related to the refresh token is valid, we use it, delete the old one, and generate a new one.If there is any issue, we return an error message.
    }

}

