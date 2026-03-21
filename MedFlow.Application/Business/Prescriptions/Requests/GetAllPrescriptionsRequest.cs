
using Application.Business.Prescriptions.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Prescriptions.Requests;

public record class GetAllPrescriptionsRequest : IRequest<ListResult<GetAllPrescriptionsResponse>>
{

}
