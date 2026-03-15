


namespace Application.Business.Appointments.Responses;

public class GetTodayAppointmentsResponse
{
    public Guid DoctorId { get; set; }

    public Guid PatientId { get; set; }

    public DateOnly AppointmentDate { get; set; }
    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public byte AppointmentType { get; set; }

    public byte Status { get; set; }

    public int QueueNumber { get; set; }
}
