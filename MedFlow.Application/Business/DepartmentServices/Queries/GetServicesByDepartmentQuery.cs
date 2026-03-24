
using Application.Business.DepartmentServices.Requests;
using Application.Business.DepartmentServices.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.DepartmentServices.Queries;

internal sealed class GetServicesByDepartmentQuery : SysRequestHandler<GetServicesByDepartmentRequest, ListResult<GetServicesByDepartmentResponse>>
{

    private readonly SqlUnitOfWork _sqlUnitOfWork;

    private readonly IMapper _mapper;

    public GetServicesByDepartmentQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }


    public override async Task<ListResult<GetServicesByDepartmentResponse>> Handle(GetServicesByDepartmentRequest request, CancellationToken cancellationToken)
    {
        var department = await _sqlUnitOfWork.DepartmentRepository.GetByIdAsync(request.Id, cancellationToken);

        ThrowNotFoundIfNull(department, "Department Not Found");

        var departmentServices = await _sqlUnitOfWork.DepartmentServiceRepository.GetByDepartmentIdAsync(request.Id, cancellationToken);

        var response = _mapper.Map<List<GetServicesByDepartmentResponse>>(departmentServices);

        return new ListResult<GetServicesByDepartmentResponse> { Data = response };
    }
}
