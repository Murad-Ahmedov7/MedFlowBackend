
using Domain.ResponseModel;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Business.Departments.Requests;

public record class DeleteDepartmentRequest : IRequest<Result>
{
    [JsonIgnore]
    public Guid Id { get; set; }
}
