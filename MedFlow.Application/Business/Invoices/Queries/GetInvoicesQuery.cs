
using Application.Business.Invoices.Requests;
using Application.Business.Invoices.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.Invoices.Queries;

internal sealed class GetInvoicesQuery : SysRequestHandler<GetInvoicesRequest, ListResult<InvoiceResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;
    private readonly IMapper _mapper;

    public GetInvoicesQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<ListResult<InvoiceResponse>> Handle(GetInvoicesRequest request, CancellationToken cancellationToken)
    {
        var invoices = await _sqlUnitOfWork.InvoiceRepository.GetAllWithDetailsAsync(cancellationToken);

        var response = _mapper.Map<List<InvoiceResponse>>(invoices);

        return new ListResult<InvoiceResponse> { Data = response };
    }
}
