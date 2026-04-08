
using Application.Business.Users.Extensions;
using Application.Business.Users.Requests;
using Application.Business.Users.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.Entities.Auth;
using Domain.Entities.Auth.Enums;
using Domain.Exceptions;
using Domain.ResponseModel;
using Isopoh.Cryptography.Argon2;

namespace Application.Business.Users.Commands;

internal sealed class SignUpUserCommand : SysRequestHandler<SignUpUserRequest, Result<SignUpUserResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;

    private readonly IMapper _mapper;

    public SignUpUserCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        : base(currentUserService)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<Result<SignUpUserResponse>> Handle(SignUpUserRequest request, CancellationToken cancellationToken)
    {
        var emailExists = await _sqlUnitOfWork.UserRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (emailExists != null)
        {
            ThrowUserError("Email already exists.");
        }

        var currentRole = GetCurrentUserRoleOrThrow();

        Enum.TryParse<UserRole>(request.UserRole, true, out var targetRole);

        if (!currentRole.CanCreate(targetRole))
        {
            throw new ForbiddenException("You are not allowed to create this role.");
        }

        var passwordHash = Argon2.Hash(request.Password);

        var newUser = _mapper.Map<User>(request);
        newUser.PasswordHash = passwordHash;
        newUser.CreatedAt = DateTime.UtcNow;
        newUser.CreatedBy = GetCurrentUserIdOrThrow();


        _sqlUnitOfWork.UserRepository.Add(newUser);
        await _sqlUnitOfWork.SaveChangesAsync();

        var response = _mapper.Map<SignUpUserResponse>(newUser);

        return new Result<SignUpUserResponse>
        {
            Data = response
        };
    }

}

