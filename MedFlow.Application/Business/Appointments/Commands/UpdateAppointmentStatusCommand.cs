

using Application.Business.Appointments.Requests;
using Application.Business.Appointments.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.Entities.Appointments.Enums;
using Domain.ResponseModel;

namespace Application.Business.Appointments.Commands;

public sealed class UpdateAppointmentStatusCommand : SysRequestHandler<UpdateAppointmentStatusRequest, Result<UpdateAppointmentStatusResponse>>
{
    private readonly IMapper _mapper;

    private readonly SqlUnitOfWork _sqlUnitOfWork;

    public UpdateAppointmentStatusCommand(IMapper mapper, SqlUnitOfWork sqlUnitOfWork)
    {
        _mapper = mapper;
        _sqlUnitOfWork = sqlUnitOfWork;
    }



    public override async Task<Result<UpdateAppointmentStatusResponse>> Handle(UpdateAppointmentStatusRequest request, CancellationToken cancellationToken)
    {
        var appointment = await _sqlUnitOfWork.AppointmentRepository.GetByIdAsync(request.Id, cancellationToken);

        ThrowNotFoundIfNull(appointment, "Appointment Not Found");

        appointment!.Status = (Status)request.Status;

        _sqlUnitOfWork.AppointmentRepository.Update(appointment);

        await _sqlUnitOfWork.SaveChangesAsync();
        var result = _mapper.Map<UpdateAppointmentStatusResponse>(appointment);

        return new Result<UpdateAppointmentStatusResponse> { Data = result };
    }
}
