
using Application.Business.Departments.Requests;
using Application.Business.Departments.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.Departments.Commands;

internal sealed class UpdateDepartmentCommand : SysRequestHandler<UpdateDepartmentRequest, Result<DepartmentResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;
    private readonly IMapper _mapper;

    public UpdateDepartmentCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<Result<DepartmentResponse>> Handle(UpdateDepartmentRequest request, CancellationToken cancellationToken)
    {
        var department = await _sqlUnitOfWork.DepartmentRepository.GetByIdAsync(request.Id, cancellationToken);

        ThrowNotFoundIfNull(department, "Department tapılmadı");

        department!.Name = request.Name;

        _sqlUnitOfWork.DepartmentRepository.Update(department);

        await _sqlUnitOfWork.SaveChangesAsync();

        var response = _mapper.Map<DepartmentResponse>(department);

        return new Result<DepartmentResponse> { Data = response };
    }
}
