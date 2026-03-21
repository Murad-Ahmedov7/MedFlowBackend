

using Application.Business.Prescriptions.Requests;
using Application.Business.Prescriptions.Responses;
using Application.Infrastructure;
using AutoMapper;

using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.Prescriptions.Queries;

public sealed class GetPrescriptionByIdQuery : SysRequestHandler<GetPrescriptionByIdRequest, Result<GetPrescriptionByIdResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;
    private readonly IMapper _mapper;

    public GetPrescriptionByIdQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<Result<GetPrescriptionByIdResponse>> Handle(GetPrescriptionByIdRequest request, CancellationToken cancellationToken)
    {
        var prescription=await _sqlUnitOfWork.PrescriptionRepository.GetByIdWithDetailsAsync(request.Id,cancellationToken);

        ThrowNotFoundIfNull(prescription,"Prescription Not Found");

        var result =_mapper.Map<GetPrescriptionByIdResponse>(prescription);

        return new Result<GetPrescriptionByIdResponse> { Data = result };
    }
}
