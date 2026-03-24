


using Application.Business.DepartmentServices.Responses;
using Domain.ResponseModel;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Business.DepartmentServices.Requests;

public record class CreateDepartmentServiceRequest:IRequest<Result<DepartmentServiceResponse>>
{
    [JsonIgnore]
    public Guid DepartmentId { get; set; }

    public Guid ServiceId { get; set; }

    public decimal Price { get; set; }
}

