

using Application.Business.Appointments.Requests;
using Application.Business.Patients.Responses;
using Application.Infrastructure;
using AutoMapper;
using DataAccess.Core;
using Domain.Entities.Appointments;
using Domain.Exceptions;
using Domain.ResponseModel;
using Microsoft.EntityFrameworkCore;
using DayOfWeek = Domain.Entities.DoctorSchedules.Enums.DayOfWeek;

namespace Application.Business.Appointments.Commands;

internal sealed class CreateAppointmentCommand : SysRequestHandler<CreateAppointmentRequest, Result<CreateAppointmentResponse>>
{
    private readonly SqlUnitOfWork _sqlUnitOfWork;
    private readonly IMapper _mapper;
    public CreateAppointmentCommand(SqlUnitOfWork sqlUnitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        : base(currentUserService)
    {
        _sqlUnitOfWork = sqlUnitOfWork;
        _mapper = mapper;
    }

    public override async Task<Result<CreateAppointmentResponse>> Handle(CreateAppointmentRequest request, CancellationToken cancellationToken)
    {

        var patient = await _sqlUnitOfWork.PatientRepository.GetByIdAsync(request.PatientId, cancellationToken);

        ThrowNotFoundIfNull(patient, "Pasiyent Tapılmadı");

        var doctor = await _sqlUnitOfWork.DoctorRepository.GetByIdAsync(request.DoctorId, cancellationToken);

        ThrowNotFoundIfNull(doctor, "Doctor Tapılmadı");




        var hasOverlap = await _sqlUnitOfWork.AppointmentRepository.HasAppointmentOverlapAsync(request.DoctorId, request.AppointmentDate, request.StartTime, request.EndTime);

        if (hasOverlap) throw new ConflictException("The doctor already has an appointment in the selected time range.");





        var appointmentWeekDay = (DayOfWeek)request.AppointmentDate.DayOfWeek;

        var doctorSchedule = await _sqlUnitOfWork.DoctorScheduleRepository.GetDoctorScheduleByDoctorAndDayAsync(request.DoctorId, appointmentWeekDay, cancellationToken);

        ThrowNotFoundIfNull(doctorSchedule, "The doctor does not have a schedule for the selected day.");





        var workingHours = request.StartTime >= doctorSchedule.StartTime && request.EndTime <= doctorSchedule.EndTime;

        if (!workingHours) throw new ConflictException("The appointment time is outside the doctor's working hours.");




        var newAppointment = _mapper.Map<Appointment>(request);

        newAppointment.CreatedAt = DateTime.UtcNow;

        newAppointment.CreatedBy = GetCurrentUserIdOrThrow();

        newAppointment.QueueNumber = await _sqlUnitOfWork.AppointmentRepository.GetMaxQueueNumberAsync(request.DoctorId, request.AppointmentDate, cancellationToken) + 1;

        _sqlUnitOfWork.AppointmentRepository.Add(newAppointment);

        await _sqlUnitOfWork.SaveChangesAsync();

        var result = _mapper.Map<CreateAppointmentResponse>(newAppointment);

        return new Result<CreateAppointmentResponse> { Data = result };
    }
}





