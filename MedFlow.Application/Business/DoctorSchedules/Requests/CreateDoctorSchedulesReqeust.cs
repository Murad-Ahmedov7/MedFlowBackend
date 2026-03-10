
using Application.Business.DoctorSchedules.Responses;
using Domain.ResponseModel;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Business.DoctorSchedules.Requests;

public record class CreateDoctorSchedulesReqeust : IRequest<ListResult<DoctorScheduleResponse>>
{
    [JsonIgnore]
    public Guid DoctorId { get; set; }
    public List<CreateDoctorScheduleRequest> Schedules { get; set; } = [];

}

