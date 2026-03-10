

namespace Application.Business.DoctorSchedules.Requests;

public record class CreateDoctorScheduleRequest
{
    public byte DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }
}

