

using Application.Business.Doctors.Requests;
using Application.Business.Doctors.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.Entities.Doctors;
using Domain.ResponseModel;

namespace Application.Business.Doctors.Commands;

internal sealed class CreateDoctorCommand : SysRequestHandler<CreateDoctorRequest, Result<DoctorResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;

    private readonly IMapper _mapper;


    public CreateDoctorCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        : base(currentUserService)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<Result<DoctorResponse>> Handle(CreateDoctorRequest request, CancellationToken cancellationToken)
    {
        var user = await _sqlUnitOfWork.UserRepository.GetByIdAsync(request.UserId,cancellationToken);
        ThrowNotFoundIfNull(user, "User tapılmadı");

        var department = await _sqlUnitOfWork.DepartmentRepository.GetByIdAsync(request.DepartmentId,cancellationToken);
        ThrowNotFoundIfNull(department, "Departament tapılmadı");

        var newDoctor = _mapper.Map<Doctor>(request);

        newDoctor.CreatedAt = DateTime.UtcNow;

        newDoctor.CreatedBy = GetCurrentUserIdOrThrow();

        _sqlUnitOfWork.DoctorRepository.Add(newDoctor);
        await _sqlUnitOfWork.SaveChangesAsync();

        var result = _mapper.Map<DoctorResponse>(newDoctor);

        return new Result<DoctorResponse> { Data = result };

    }

}
