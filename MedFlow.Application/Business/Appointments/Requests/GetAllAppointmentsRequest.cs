
using Application.Business.Appointments.Responses;
using Domain.ResponseModel;
using MediatR;

namespace Application.Business.Appointments.Requests;

public record class GetAllAppointmentsRequest : IRequest<ListResult<AppointmentResponse>>
{

}
