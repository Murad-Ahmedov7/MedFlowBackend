
using Application.Business.Services.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Services.Requests;

public record class GetAllServicesRequest : IRequest<ListResult<ServiceResponse>>
{

}
