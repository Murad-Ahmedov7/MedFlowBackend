
using Domain.Entities.Appointments.Enums;
using Domain.Entities.Base;
using Domain.Entities.Doctors;
using Domain.Entities.Patients;


namespace Domain.Entities.Appointments;

public class Appointment : BaseEntity
{
    public Guid DoctorId { get; set; }
    public Guid PatientId { get; set; }
    public DateOnly AppointmentDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public AppointmentType AppointmentType { get; set; }

    public Status Status { get; set; }

    public int QueueNumber { get; set; }

    public Doctor Doctor { get; set; } = null!;

    public Patient Patient { get; set; } = null!;

}

