

namespace Application.Business.DoctorSchedules.Responses;
public class DoctorScheduleResponse
{
    public Guid Id { get; set; }

    public Guid DoctorId { get; set; }

    public byte DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }
}

