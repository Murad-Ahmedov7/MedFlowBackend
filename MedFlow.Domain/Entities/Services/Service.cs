
using Domain.Entities.Base;
using Domain.Entities.DepartmentServices;

namespace Domain.Entities.Services;

public class Service : BaseEntity
{
    public string Name { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public ICollection<DepartmentService> DepartmentServices { get; set; } = null!;

}
