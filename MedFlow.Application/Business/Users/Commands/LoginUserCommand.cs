using Application.Business.Users.Requests;
using Application.Business.Users.Responses;
using Application.Infrastructure;
using DataAccess.Core;
using Domain.Entities;
using Domain.ResponseModel;
using Isopoh.Cryptography.Argon2;


namespace Application.Business.Users.Commands
{
    internal sealed class LoginUserCommand : SysRequestHandler<LoginUserRequest, Result<LoginUserResponse>>
    {
        private readonly SqlUnitOfWork _sqlUnitOfWork;
        private readonly ITokenProvider _tokenProvider;

        public LoginUserCommand(SqlUnitOfWork sqlUnitOfWork, ICurrentUserService currentUserService,ITokenProvider tokenProvider)
            : base(currentUserService)
        {
            _sqlUnitOfWork = sqlUnitOfWork;
            _tokenProvider = tokenProvider;
        }

        public override async Task<Result<LoginUserResponse>> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _sqlUnitOfWork.UserRepository.GetByEmailAsync(request.Email);




            //ThrowUserErrorIfNull(user, "Invalid email or password.");

            if (user == null || string.IsNullOrEmpty(user.PasswordHash))
            {
                return new Result<LoginUserResponse>(["Invalid email or password."]);
            }

            var isPasswordValid = Argon2.Verify(user.PasswordHash, request.Password);


            if (!isPasswordValid)
            {
                return new Result<LoginUserResponse>(["Invalid email or password."]);
            }



            //ThrowUserError("Invalid email or password.");




            //if (!isPasswordValid)
            //{
            //    ThrowUserError("Invalid email or password.");
            //}

            var token = _tokenProvider.GenerateAccessToken(user);

            var refreshToken = _tokenProvider.GenerateRefreshToken();


            _sqlUnitOfWork.AuthRepository.Add(new RefreshToken
            {
                UserId = user.Id,
                Token = refreshToken,
                ExpiresOnUtc = DateTime.UtcNow.AddDays(7), // Refresh token expires in 7 
                AbsoluteExpiresOnUtc= DateTime.UtcNow.AddDays(30) // Absolute expiration in 30 days


            });

            await _sqlUnitOfWork.SaveChangesAsync();

            var response = new LoginUserResponse
            {
                Token = token,
                RefreshToken = refreshToken
            };



            return new Result<LoginUserResponse>
            {
                Data = response
            };

        }




        






    }
    
}
