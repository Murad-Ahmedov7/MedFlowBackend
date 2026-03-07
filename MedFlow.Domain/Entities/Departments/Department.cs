

using Domain.Entities.Base;
using Domain.Entities.Doctors;

namespace Domain.Entities.Departments;

public class Department:BaseEntity
{

    public string Name { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public ICollection<Doctor> Doctors { get; set; }=null!;

}


