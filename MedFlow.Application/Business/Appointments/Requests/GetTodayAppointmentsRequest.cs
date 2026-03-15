
using Application.Business.Appointments.Responses;

using Domain.ResponseModel;
using MediatR;
using System.Net;


namespace Application.Business.Appointments.Requests;

public record class GetTodayAppointmentsRequest : IRequest<ListResult<GetTodayAppointmentsResponse>>
{

}