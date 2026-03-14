


using Application.Business.Patients.Responses;
using Domain.ResponseModel;
using MediatR;


namespace Application.Business.Appointments.Requests;

public record class CreateAppointmentRequest : IRequest<Result<CreateAppointmentResponse>>
{
    public Guid DoctorId { get; set; }

    public Guid PatientId { get; set; }

    public DateOnly AppointmentDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public byte AppointmentType { get; set; }

    public byte Status { get; set; }

}


