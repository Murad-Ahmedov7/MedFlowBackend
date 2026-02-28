

using Application.Business.Patients.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Patients.Requests;

public record class GetPatientsByNameRequest : IRequest<ListResult<PatientResponse>>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}