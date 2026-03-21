

using Application.Business.Prescriptions.Requests;
using Application.Business.Prescriptions.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.Prescriptions.Queries;

public sealed class GetPrescriptionItemsQuery : SysRequestHandler<GetPrescriptionItemsRequest, ListResult<GetPrescriptionItemsResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;

    private readonly IMapper _mapper;

    public GetPrescriptionItemsQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<ListResult<GetPrescriptionItemsResponse>> Handle(GetPrescriptionItemsRequest request, CancellationToken cancellationToken)
    {
        var prescriptionItem = await _sqlUnitOfWork.PrescriptionRepository.GetItemsByPrescriptionIdAsync(request.Id,cancellationToken);

        ThrowNotFoundIfNull(prescriptionItem, "Prescription item Not Found");

        var response = _mapper.Map<List<GetPrescriptionItemsResponse>>(prescriptionItem);

        return new ListResult<GetPrescriptionItemsResponse> { Data = response };
    }
}
