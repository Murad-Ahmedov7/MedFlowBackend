

using Application.Business.Prescriptions.Requests;
using Application.Business.Prescriptions.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.Entities.Prescriptions;
using Domain.Exceptions;
using Domain.ResponseModel;


namespace Application.Business.Prescriptions.Commands;


public sealed class AddPrescriptionItemCommand : SysRequestHandler<AddPrescriptionItemRequest, Result<AddPrescriptionItemResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;
    private readonly IMapper _mapper;

    public AddPrescriptionItemCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<Result<AddPrescriptionItemResponse>> Handle(AddPrescriptionItemRequest request, CancellationToken cancellationToken)

    {
        var prescription = await _sqlUnitOfWork.PrescriptionRepository.GetByIdAsync(request.PrescriptionId, cancellationToken);

        ThrowNotFoundIfNull(prescription, "Prescription Not Found");


        var medicine = await _sqlUnitOfWork.MedicineRepository.GetByIdAsync(request.MedicineId, cancellationToken);

        ThrowNotFoundIfNull(medicine, "Medicine Not Found");

        var newPrescriptionItem = _mapper.Map<PrescriptionItem>(request);

        prescription!.PrescriptionItems = new List<PrescriptionItem>();

        var isDuplicate = await _sqlUnitOfWork.PrescriptionRepository.IsPrescriptionItemDuplicateAsync(newPrescriptionItem, cancellationToken);

        if (isDuplicate) throw new ConflictException("This medicine has already been added with the same usage parameters.");


        prescription.PrescriptionItems.Add(newPrescriptionItem);

        await _sqlUnitOfWork.SaveChangesAsync();


        var response = _mapper.Map<AddPrescriptionItemResponse>(newPrescriptionItem);

        return new Result<AddPrescriptionItemResponse> { Data = response };

    }
}

