

using Application.Business.Medicines.Requests;
using Application.Business.Medicines.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.Entities.Medicines;
using Domain.ResponseModel;

namespace Application.Business.Medicines.Commands;

public sealed class CreateMedicineCommand : SysRequestHandler<CreateMedicineRequest, Result<MedicineResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;

    private readonly IMapper _mapper;



    public CreateMedicineCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        : base(currentUserService)
    {
        _mapper = mapper;
        _sqlUnitOfWork = sqlUnitOfWork;
    }

    public override async Task<Result<MedicineResponse>> Handle(CreateMedicineRequest request, CancellationToken cancellationToken)
    {
     
        var newMedicine = _mapper.Map<Medicine>(request);

        newMedicine.CreatedAt = DateTime.Now;
        newMedicine.CreatedBy = GetCurrentUserIdOrThrow();


        _sqlUnitOfWork.MedicineRepository.Add(newMedicine);

        await _sqlUnitOfWork.SaveChangesAsync();

        var result = _mapper.Map<MedicineResponse>(newMedicine);

        return new Result<MedicineResponse> { Data = result };
    }
}
