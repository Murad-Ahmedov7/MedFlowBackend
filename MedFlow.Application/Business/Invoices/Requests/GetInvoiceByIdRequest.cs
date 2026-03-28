
using Application.Business.Invoices.Responses;
using Domain.ResponseModel;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Business.Invoices.Requests;

public record class GetInvoiceByIdRequest : IRequest<Result<InvoiceResponse>>
{
    [JsonIgnore]
    public Guid Id { get; set; } 
}
