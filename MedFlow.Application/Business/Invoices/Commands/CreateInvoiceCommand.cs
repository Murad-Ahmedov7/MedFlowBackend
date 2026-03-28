
using Application.Business.Invoices.Requests;
using Application.Business.Invoices.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.Entities.Billing.Invoices;
using Domain.ResponseModel;

namespace Application.Business.Invoices.Commands;

internal sealed class CreateInvoiceCommand : SysRequestHandler<CreateInvoiceRequest, Result<CreateInvoiceResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;

    private readonly IMapper _mapper;

    public CreateInvoiceCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        : base(currentUserService)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<Result<CreateInvoiceResponse>> Handle(CreateInvoiceRequest request, CancellationToken cancellationToken)
    {
        var patient = await _sqlUnitOfWork.PatientRepository.GetByIdAsync(request.PatientId, cancellationToken);

        ThrowNotFoundIfNull(patient, "Patient not found");


        var newInvoice = new Invoice(request.PatientId);


        foreach (var item in request.InvoiceItems)
        {

            var departmentService = await _sqlUnitOfWork.DepartmentServiceRepository.GetByIdAsync(item.DepartmentServiceId, cancellationToken);

            ThrowNotFoundIfNull(departmentService, "Service not found in this department");

            var price = departmentService!.Price;

            var service = await _sqlUnitOfWork.ServiceRepository.GetByIdAsync(departmentService.ServiceId, cancellationToken);

            ThrowNotFoundIfNull(service, "Service not found");


            var invoiceItem = new InvoiceItem(
                newInvoice.Id,
                item.DepartmentServiceId,
                service!.Name,
                price,
                item.Quantity
                );

            invoiceItem.CreatedAt = DateTime.UtcNow;


            newInvoice.AddItem(invoiceItem);
        }

        newInvoice.CreatedAt = DateTime.UtcNow; 
        newInvoice.CreatedBy = GetCurrentUserIdOrThrow();


        _sqlUnitOfWork.InvoiceRepository.Add(newInvoice);


        await _sqlUnitOfWork.SaveChangesAsync();


        var response = _mapper.Map<CreateInvoiceResponse>(newInvoice);


        return new Result<CreateInvoiceResponse> { Data = response };
    }
}