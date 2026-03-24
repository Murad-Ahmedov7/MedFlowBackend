
using Application.Business.DepartmentServices.Requests;
using Application.Business.DepartmentServices.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.Entities.DepartmentServices;
using Domain.Exceptions;
using Domain.ResponseModel;

namespace Application.Business.DepartmentServices.Commands;

internal sealed class CreateDeparmentServiceCommand : SysRequestHandler<CreateDepartmentServiceRequest, Result<DepartmentServiceResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;

    private readonly IMapper _mapper;

    public CreateDeparmentServiceCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<Result<DepartmentServiceResponse>> Handle(CreateDepartmentServiceRequest request, CancellationToken cancellationToken)
    {
        var department = await _sqlUnitOfWork.DepartmentRepository.GetByIdAsync(request.DepartmentId, cancellationToken);

        ThrowNotFoundIfNull(department, "Deparment Not Found");

        var service = await _sqlUnitOfWork.ServiceRepository.GetByIdAsync(request.ServiceId, cancellationToken);

        ThrowNotFoundIfNull(service, "Service Not Found");

        var newDeparmentService = _mapper.Map<DepartmentService>(request);

        newDeparmentService.IsActive = true;

        var exists = await _sqlUnitOfWork.DepartmentServiceRepository.ExistsByDepartmentAndServiceAsync(request.DepartmentId,request.ServiceId, cancellationToken);

        if (exists) throw new ConflictException("This service is already added to the department");

        _sqlUnitOfWork.DepartmentServiceRepository.Add(newDeparmentService);

        await _sqlUnitOfWork.SaveChangesAsync();


        var response = _mapper.Map<DepartmentServiceResponse>(newDeparmentService);

        return new Result<DepartmentServiceResponse> { Data = response };


    }
}
