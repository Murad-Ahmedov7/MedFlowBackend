

using Application.Business.Appointments.Responses;
using Domain.ResponseModel;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Business.Appointments.Requests;

public record class UpdateAppointmentStatusRequest:IRequest<Result<UpdateAppointmentStatusResponse>>
{
    [JsonIgnore]
    public Guid Id { get; set; }

    public byte Status { get; set; }
}

