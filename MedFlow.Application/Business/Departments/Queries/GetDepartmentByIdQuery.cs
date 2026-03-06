using Application.Business.Departments.Requests;
using Application.Business.Departments.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;


namespace Application.Business.Departments.Queries;

internal sealed class GetDepartmentByIdQuery : SysRequestHandler<GetDepartmentByIdRequest, Result<DepartmentResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;
    private readonly IMapper _mapper;


    public GetDepartmentByIdQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }


    public override async Task<Result<DepartmentResponse>> Handle(GetDepartmentByIdRequest request, CancellationToken cancellationToken)
    {
        var department = await _sqlUnitOfWork.DepartmentRepository.GetByIdAsync(request.Id, cancellationToken);

        ThrowNotFoundIfNull(department, "Departament tapılmadı");

        var response = _mapper.Map<DepartmentResponse>(department);

        return new Result<DepartmentResponse> { Data = response };
    }
}
