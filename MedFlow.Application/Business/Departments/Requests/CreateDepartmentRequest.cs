

using Application.Business.Departments.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Departments.Requests;

public record class CreateDepartmentRequest : IRequest<Result<DepartmentResponse>>
{
    public string Name { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }


}

