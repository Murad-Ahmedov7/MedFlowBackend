

using Application.Business.Prescriptions.Responses;
using Domain.ResponseModel;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Business.Prescriptions.Requests;

public record class AddPrescriptionItemRequest:IRequest<Result<AddPrescriptionItemResponse>>
{
    [JsonIgnore]
    public Guid PrescriptionId { get; set; }

    public Guid MedicineId { get; set; }

    public decimal Dose { get; set; }

    public int DurationInDays { get; set; }

    public int Frequency { get; set; }

    public string? UsageInstruction { get; set; }

}

