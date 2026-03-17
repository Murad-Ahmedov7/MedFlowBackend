


using Application.Business.Medicines.Requests;
using Application.Business.Medicines.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.Medicines.Queries;
public sealed class GetMedicineByQuery : SysRequestHandler<GetMedicineByIdRequest, Result<MedicineResponse>>
{
    private readonly IMapper _mapper;
    private readonly SqlUnitOfWork _sqlUnitOfWork;

    public GetMedicineByQuery(IMapper mapper, SqlUnitOfWork sqlUnitOfWork)
    {
        _mapper = mapper;
        _sqlUnitOfWork = sqlUnitOfWork;

    }

    public override async Task<Result<MedicineResponse>> Handle(GetMedicineByIdRequest request, CancellationToken cancellationToken)
    {
        var medicine = await _sqlUnitOfWork.MedicineRepository.GetByIdAsync(request.Id, cancellationToken);

        ThrowNotFoundIfNull(medicine, "Medicine Not Found");

        var response = _mapper.Map<MedicineResponse>(medicine);

        return new Result<MedicineResponse> { Data = response };
    }
}

