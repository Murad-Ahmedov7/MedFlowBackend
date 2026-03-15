

using Application.Business.Appointments.Requests;
using Application.Business.Appointments.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.Appointments.Queries;

internal sealed class GetTodayAppointmentsQuery : SysRequestHandler<GetTodayAppointmentsRequest, ListResult<GetTodayAppointmentsResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;

    private readonly IMapper _mapper;

    public GetTodayAppointmentsQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper, ICurrentUserService currentUserService) 
        :base(currentUserService)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<ListResult<GetTodayAppointmentsResponse>> Handle(GetTodayAppointmentsRequest request, CancellationToken cancellationToken)
    {
        var userId = GetCurrentUserId();

        var role = GetCurrentUserRoleOrThrow();

        Console.WriteLine(role);


        var todayAppointments = await _sqlUnitOfWork.AppointmentRepository.GetTodayAppointmentsAsync(userId??Guid.Empty,role, cancellationToken);

        var response = _mapper.Map<List<GetTodayAppointmentsResponse>>(todayAppointments);

        return new ListResult<GetTodayAppointmentsResponse> { Data = response };
    }

}