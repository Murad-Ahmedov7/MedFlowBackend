
using Application.Business.Payments.Requests;
using Application.Business.Payments.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.Entities.Billing.Payments;
using Domain.Entities.Billing.Payments.Enums;
using Domain.ResponseModel;

namespace Application.Business.Payments.Commands;

internal sealed class CreatePaymentCommand : SysRequestHandler<CreatePaymentRequest, Result<PaymentResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;
    private readonly IMapper _mapper;

    public CreatePaymentCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<Result<PaymentResponse>> Handle(CreatePaymentRequest request, CancellationToken cancellationToken)
    {
        var invoice = await _sqlUnitOfWork.InvoiceRepository.GetByIdAsync(request.InvoiceId, cancellationToken);

        ThrowNotFoundIfNull(invoice, "Invoice not found");

        invoice!.AddPayment(request.Amount);

        var payment = new Payment(
        request.InvoiceId,
        request.Amount,
        (PaymentMethod)request.PaymentMethod,
        request.PaymentDate ?? DateTime.UtcNow
        );

        payment.CreatedAt = DateTime.UtcNow;


        _sqlUnitOfWork.PaymentRepository.Add(payment);

        await _sqlUnitOfWork.SaveChangesAsync();

        var response = _mapper.Map<PaymentResponse>(payment);

        return new Result<PaymentResponse> { Data = response };

    }
}