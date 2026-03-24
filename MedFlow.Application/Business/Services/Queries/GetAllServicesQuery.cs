


using Application.Business.Services.Requests;
using Application.Business.Services.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.Services.Queries;

internal sealed class GetAllServicesQuery : SysRequestHandler<GetAllServicesRequest, ListResult<ServiceResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;

    private readonly IMapper _mapper;

    public GetAllServicesQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<ListResult<ServiceResponse>> Handle(GetAllServicesRequest request, CancellationToken cancellationToken)
    {
        var services = await _sqlUnitOfWork.ServiceRepository.GetAllAsync(cancellationToken);

        var response = _mapper.Map<List<ServiceResponse>>(services);

        return new ListResult<ServiceResponse> { Data = response };
    }
}
