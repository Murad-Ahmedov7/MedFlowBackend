
using Domain.Entities.Base;
using Domain.Entities.Doctors;
using DayOfWeek = Domain.Entities.DoctorSchedules.Enums.DayOfWeek;

namespace Domain.Entities.DoctorSchedules;

public class DoctorSchedule:BaseEntity
{
    public Guid DoctorId { get; set; }

    public DayOfWeek DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public Doctor Doctor { get; set; } = null!;
}
