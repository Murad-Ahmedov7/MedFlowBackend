

using Application.Business.Services.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Services.Requests;

public record class GetServiceByIdRequest : IRequest<Result<ServiceResponse>>
{
    public Guid Id { get; set; }
}
