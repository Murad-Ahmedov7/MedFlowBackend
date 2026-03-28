
using Application.Business.Invoices.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Invoices.Requests;

public record class GetInvoicesRequest : IRequest<ListResult<InvoiceResponse>>
{

}
