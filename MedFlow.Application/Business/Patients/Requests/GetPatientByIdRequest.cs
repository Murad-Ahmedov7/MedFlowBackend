
using Application.Business.Patients.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Patients.Requests;

public record class GetPatientByIdRequest : IRequest<Result<PatientResponse>>
{
    public Guid Id { get; set; }
}
