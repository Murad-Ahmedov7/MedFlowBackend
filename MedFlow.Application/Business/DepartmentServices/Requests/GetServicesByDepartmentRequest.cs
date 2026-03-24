
using Application.Business.DepartmentServices.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.DepartmentServices.Requests;

public record class GetServicesByDepartmentRequest:IRequest<ListResult<GetServicesByDepartmentResponse>>
{
    public Guid Id { get; set; }
}
