

using Application.Business.Doctors.Requests; 
using Application.Business.Doctors.Responses;
using Application.Business.Users.Extensions;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.Entities.Auth;
using Domain.Entities.Auth.Enums;
using Domain.Entities.Doctors;
using Domain.Exceptions;
using Domain.ResponseModel;
using Isopoh.Cryptography.Argon2;

namespace Application.Business.Doctors.Commands;

internal sealed class CreateDoctorCommand : SysRequestHandler<CreateDoctorRequest, Result<CreateDoctorResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;

    private readonly IMapper _mapper;


    public CreateDoctorCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        : base(currentUserService)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<Result<CreateDoctorResponse>> Handle(CreateDoctorRequest request, CancellationToken cancellationToken)
    {
        var emailExists = await _sqlUnitOfWork.UserRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (emailExists != null) throw new ConflictException("Email already exists.");

        var departmentExists = await _sqlUnitOfWork.DepartmentRepository.GetByIdAsync(request.DepartmentId, cancellationToken);

        ThrowNotFoundIfNull(departmentExists, "Department not found.");


        var currentRole = GetCurrentUserRoleOrThrow();

        var targetRole = UserRole.Doctor;

        if (!currentRole.CanCreate(targetRole)) throw new ForbiddenException($"Role '{currentRole}' is not permitted to create '{targetRole}'.");

        var passwordHash = Argon2.Hash(request.Password);

        var user = new User
        {
            FullName = request.FullName,
            Email = request.Email,
            Phone = request.Phone,
            UserRole = targetRole,
            PasswordHash = passwordHash,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = GetCurrentUserIdOrThrow()
        };

        //_sqlUnitOfWork.UserRepository.Add(user);
        //await _sqlUnitOfWork.SaveChangesAsync();


        var doctor = new Doctor
        {
            //UserId = user.Id,
            User = user,
            DepartmentId = request.DepartmentId,
            Specialty = request.Specialty,
            ImageUrl = request.ImageUrl,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = GetCurrentUserIdOrThrow()
        };
        //_sqlUnitOfWork.UserRepository.Add(user);
        _sqlUnitOfWork.DoctorRepository.Add(doctor);

        await _sqlUnitOfWork.SaveChangesAsync();

        var response = new CreateDoctorResponse
        {
            Id = doctor.Id
        };

        return new Result<CreateDoctorResponse> { Data = response };

    }

}