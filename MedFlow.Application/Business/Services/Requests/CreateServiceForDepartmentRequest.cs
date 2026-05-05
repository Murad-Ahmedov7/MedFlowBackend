
using Application.Business.Services.Responses;
using Domain.ResponseModel;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Business.Services.Requests;

public record class CreateServiceForDepartmentRequest : IRequest<Result<CreateServiceForDepartmentResponse>>
{
    [JsonIgnore]
    public Guid DepartmentId { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }
}
