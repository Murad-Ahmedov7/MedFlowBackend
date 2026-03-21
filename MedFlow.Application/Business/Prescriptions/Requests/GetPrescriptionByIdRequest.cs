


using Application.Business.Prescriptions.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Prescriptions.Requests;

public record class GetPrescriptionByIdRequest : IRequest<Result<GetPrescriptionByIdResponse>>
{
    public Guid Id { get; set; }
}
