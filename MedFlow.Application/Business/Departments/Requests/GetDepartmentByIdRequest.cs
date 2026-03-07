

using Application.Business.Departments.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Departments.Requests;

public record class GetDepartmentByIdRequest : IRequest<Result<DepartmentResponse>>
{
    public Guid Id { get; set; }
}

