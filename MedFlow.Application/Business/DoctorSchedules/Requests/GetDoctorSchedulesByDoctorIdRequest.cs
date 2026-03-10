
using Application.Business.DoctorSchedules.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.DoctorSchedules.Requests
{
    public record class GetDoctorSchedulesByDoctorIdRequest : IRequest<ListResult<DoctorScheduleResponse>>
    {
        public Guid DoctorId { get; set; }
    }
}
