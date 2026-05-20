
using Application.Business.Patients.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Patients.Requests;

public record class GetAllPatientsRequest : IRequest<ListResult<PatientResponse>>
{

}
