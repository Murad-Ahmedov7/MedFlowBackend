
using Application.Business.Departments.Responses;
using Domain.ResponseModel;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Business.Departments.Requests;

public record class UpdateDepartmentRequest : IRequest<Result<DepartmentResponse>>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }
}
