

using Application.Business.Appointments.Requests;
using Application.Business.Appointments.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.ResponseModel;

namespace Application.Business.Appointments.Queries;

internal sealed class GetAppointmentByIdQuery : SysRequestHandler<GetAppointmentByIdRequest, Result<AppointmentResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;
    private readonly IMapper _mapper;


    public GetAppointmentByIdQuery(SqlUnitOfWork sqlUnitOfWork, IMapper mapper)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<Result<AppointmentResponse>> Handle(GetAppointmentByIdRequest request, CancellationToken cancellationToken)
    {

        var appointment=await _sqlUnitOfWork.AppointmentRepository.GetAppointmentByIdAsync(request.Id,cancellationToken);

        ThrowNotFoundIfNull(appointment, "Appoinment tapılmadı");

        var response = _mapper.Map<AppointmentResponse>(appointment);

        return new Result<AppointmentResponse> { Data = response };
    }
}
