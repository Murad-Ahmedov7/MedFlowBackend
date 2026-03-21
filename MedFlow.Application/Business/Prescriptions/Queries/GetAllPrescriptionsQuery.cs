
using Application.Business.Prescriptions.Requests;
using Application.Business.Prescriptions.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Prescriptions.Queries;
public sealed class GetAllPrescriptionsQuery : SysRequestHandler<GetAllPrescriptionsRequest, ListResult<GetAllPrescriptionsResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;
    private readonly IMapper _mapper;

    public GetAllPrescriptionsQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<ListResult<GetAllPrescriptionsResponse>> Handle(GetAllPrescriptionsRequest request, CancellationToken cancellationToken)
    {
        var prescriptions = await _sqlUnitOfWork.PrescriptionRepository.GetAllWithDetailsAsync(cancellationToken);

        var result = _mapper.Map<List<GetAllPrescriptionsResponse>>(prescriptions);

        return new ListResult<GetAllPrescriptionsResponse> { Data = result };
    }
}

