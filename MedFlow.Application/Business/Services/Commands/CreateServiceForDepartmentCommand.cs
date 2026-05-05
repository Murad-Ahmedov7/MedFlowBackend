
using Application.Business.Services.Requests;
using Application.Business.Services.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.Entities.Services;
using Domain.Exceptions;
using Domain.ResponseModel;

namespace Application.Business.Services.Commands;

internal sealed class CreateServiceForDepartmentCommand : SysRequestHandler<CreateServiceForDepartmentRequest, Result<CreateServiceForDepartmentResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;
    private readonly IMapper _mapper;

    public CreateServiceForDepartmentCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        : base(currentUserService)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<Result<CreateServiceForDepartmentResponse>> Handle(CreateServiceForDepartmentRequest request, CancellationToken cancellationToken)
    {

        var department = await _sqlUnitOfWork.DepartmentRepository.GetByIdAsync(request.DepartmentId, cancellationToken);

        ThrowNotFoundIfNull(department, "Department not found");

        var exists = await _sqlUnitOfWork.ServiceRepository.ExistsByNameAndDepartmentAsync(request.Name, request.DepartmentId, cancellationToken);

        if (exists) throw new ConflictException("Service already exists");

        var newService = _mapper.Map<Service>(request);

        newService.CreatedAt = DateTime.UtcNow;

        newService.CreatedBy = GetCurrentUserIdOrThrow();

        _sqlUnitOfWork.ServiceRepository.Add(newService);

        await _sqlUnitOfWork.SaveChangesAsync();

        var result = _mapper.Map<CreateServiceForDepartmentResponse>(newService);

        return new Result<CreateServiceForDepartmentResponse> { Data = result };
    }
}
