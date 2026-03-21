

using Application.Business.Prescriptions.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Prescriptions.Requests;
public record class CreatePrescriptionRequest:IRequest<Result<PrescriptionResponse>>
{
    public string Title { get; set; } = string.Empty;
    public Guid ExaminationId { get; set; }
}