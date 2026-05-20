
using Domain.ResponseModel;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Business.Patients.Requests;

public record class DeletePatientRequest : IRequest<Result>
{
    [JsonIgnore]
    public Guid Id { get; set; }
}
