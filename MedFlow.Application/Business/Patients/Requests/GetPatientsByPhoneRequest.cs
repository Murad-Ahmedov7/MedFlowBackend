using Application.Business.Patients.Responses;
using Domain.ResponseModel;
using MediatR;


namespace Application.Business.Patients.Requests;

public record class GetPatientsByPhoneRequest : IRequest<ListResult<PatientResponse>>
{
    public string Phone { get; set; } = string.Empty;
}

