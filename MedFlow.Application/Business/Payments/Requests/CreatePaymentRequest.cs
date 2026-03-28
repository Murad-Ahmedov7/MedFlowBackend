
using Application.Business.Payments.Responses;
using Domain.ResponseModel;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Business.Payments.Requests;

public record class CreatePaymentRequest : IRequest<Result<PaymentResponse>>
{
    [JsonIgnore]
    public Guid InvoiceId { get; set; }

    public decimal Amount { get; set; }

    public byte PaymentMethod {  get; set; }

    public DateTime? PaymentDate { get; set; }
}
