
using Application.Business.Services.Responses;
using Domain.ResponseModel;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Business.Services.Requests;

public record class CreateServiceRequest : IRequest<Result<CreateServiceResponse>>
{
    [JsonIgnore]
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }
}
