

using Domain.Entities.Appointments;
using Domain.Entities.Auth;
using Domain.Entities.Base;
using Domain.Entities.Departments;
using Domain.Entities.DoctorSchedules;


namespace Domain.Entities.Doctors;

public class Doctor : BaseEntity
{
    public Guid DepartmentId { get; set; }

    public Guid UserId { get; set; }

    public string Specialty { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public User User { get; set; } = null!;

    public Department Department { get; set; } = null!;

    public ICollection<DoctorSchedule> DoctorSchedules { get; set; }=null!;

    public ICollection<Appointment> Appointments { get; set; }=null!;


}

