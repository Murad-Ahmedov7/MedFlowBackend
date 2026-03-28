

using Application.Business.Invoices.Responses;
using Domain.ResponseModel;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Business.Invoices.Requests;

public record class CreateInvoiceRequest : IRequest<Result<CreateInvoiceResponse>>
{
    [JsonIgnore]
    public Guid PatientId { get; set; }

    public List<InvoiceItemRequest> InvoiceItems { get; set; } = new();
}