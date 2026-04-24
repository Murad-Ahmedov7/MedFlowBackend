
using Application.Business.Departments.Requests;
using Application.Business.Departments.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.Departments.Queries;

internal sealed class GetAllDepartmentsQuery : SysRequestHandler<GetAllDepartmentsRequest, ListResult<DepartmentResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;

    private readonly IMapper _mapper;

    public GetAllDepartmentsQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<ListResult<DepartmentResponse>> Handle(GetAllDepartmentsRequest request, CancellationToken cancellationToken)
    {
        var departments = await _sqlUnitOfWork.DepartmentRepository.GetAllAsync(cancellationToken);

        var response = _mapper.Map<List<DepartmentResponse>>(departments);

        return new ListResult<DepartmentResponse> { Data = response };
    }
}
