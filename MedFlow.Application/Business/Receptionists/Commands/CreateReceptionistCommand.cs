
using Application.Business.Receptionists.Requests;
using Application.Business.Receptionists.Responses;
using Application.Business.Users.Extensions;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.Entities.Auth;
using Domain.Entities.Auth.Enums;
using Domain.Exceptions;
using Domain.ResponseModel;
using Isopoh.Cryptography.Argon2;

namespace Application.Business.Receptionists.Commands;

internal sealed class CreateReceptionistCommand : SysRequestHandler<CreateReceptionistRequest, Result<CreateReceptionistResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;

    private readonly IMapper _mapper;

    public CreateReceptionistCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        :base(currentUserService)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<Result<CreateReceptionistResponse>> Handle(CreateReceptionistRequest request, CancellationToken cancellationToken)
    {
        var emailExists = await _sqlUnitOfWork.UserRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (emailExists != null)
        {
            ThrowUserError("Email already exists.");
        }

        var currentRole = GetCurrentUserRoleOrThrow();

        var targetRole = UserRole.Receptionist;

        if (!currentRole.CanCreate(targetRole))
        {
            throw new ForbiddenException($"Role '{currentRole}' is not permitted to create '{targetRole}'.");
        }

        var passwordHash = Argon2.Hash(request.Password);

        var newUser = _mapper.Map<User>(request);
        newUser.PasswordHash = passwordHash;
        newUser.UserRole = targetRole;
        newUser.CreatedAt = DateTime.UtcNow;
        newUser.CreatedBy = GetCurrentUserIdOrThrow();


        _sqlUnitOfWork.UserRepository.Add(newUser);
        await _sqlUnitOfWork.SaveChangesAsync();

        var response = _mapper.Map<CreateReceptionistResponse>(newUser);

        return new Result<CreateReceptionistResponse>
        {
            Data = response
        };
    }
}

