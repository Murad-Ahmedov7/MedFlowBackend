
using Application.Business.Services.Requests;
using Application.Business.Services.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.Services.Queries;

internal sealed class GetServiceByIdQuery : SysRequestHandler<GetServiceByIdRequest, Result<ServiceResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;
    private readonly IMapper _mapper;

    public GetServiceByIdQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<Result<ServiceResponse>> Handle(GetServiceByIdRequest request, CancellationToken cancellationToken)
    {
        var service = await _sqlUnitOfWork.ServiceRepository.GetByIdAsync(request.Id, cancellationToken);

        ThrowNotFoundIfNull(service, "Service Not Found");

        var response = _mapper.Map<ServiceResponse>(service);

        return new Result<ServiceResponse> { Data = response };
    }
}
