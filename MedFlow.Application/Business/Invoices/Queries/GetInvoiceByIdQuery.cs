

using Application.Business.Invoices.Requests;
using Application.Business.Invoices.Responses;
using Application.Business.Patients.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.Invoices.Queries;

internal sealed class GetInvoiceByIdQuery : SysRequestHandler<GetInvoiceByIdRequest, Result<InvoiceResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;
    private readonly IMapper _mapper;

    public GetInvoiceByIdQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<Result<InvoiceResponse>> Handle(GetInvoiceByIdRequest request, CancellationToken cancellationToken)
    {
        var invoice = await _sqlUnitOfWork.InvoiceRepository.GetByIdWithDetailsAsync(request.Id, cancellationToken);

        ThrowNotFoundIfNull(invoice, "Invoice Not Found");

        var response = _mapper.Map<InvoiceResponse>(invoice);

        return new Result<InvoiceResponse> { Data = response };
    }
}