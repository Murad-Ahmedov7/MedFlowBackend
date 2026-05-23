
using Application.Business.Users.Requests;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.Exceptions;
using Domain.ResponseModel;
using Isopoh.Cryptography.Argon2;

namespace Application.Business.Users.Commands;

internal sealed class ChangePasswordCommand : SysRequestHandler<ChangePasswordRequest, Result>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;

    private readonly IMapper _mapper;

    public ChangePasswordCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper, ICurrentUserService currentUserService) : base(currentUserService)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public async override Task<Result> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
    {
        var currentUserId = GetCurrentUserIdOrThrow();

        var user = await _sqlUnitOfWork.UserRepository.GetByIdAsync(currentUserId, cancellationToken);

        ThrowNotFoundIfNull(user, "User Not Found");

        var isPasswordValid = Argon2.Verify(user.PasswordHash, request.CurrentPassword);

        if (!isPasswordValid) throw new ClientException("Current password is incorrect.");

        user.PasswordHash = Argon2.Hash(request.NewPassword);

        await _sqlUnitOfWork.SaveChangesAsync();

        return new Result();
    }
}