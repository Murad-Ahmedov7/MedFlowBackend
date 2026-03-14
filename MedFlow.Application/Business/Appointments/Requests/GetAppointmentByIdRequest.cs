


using Application.Business.Appointments.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Appointments.Requests;
public record class GetAppointmentByIdRequest:IRequest<Result<AppointmentResponse>>
{
    public Guid Id { get; set; }
}

