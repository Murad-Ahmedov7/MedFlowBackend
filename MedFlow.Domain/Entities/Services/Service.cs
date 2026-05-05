

using Domain.Entities.Base;
using Domain.Entities.Departments;

namespace Domain.Entities.Services;

public class Service : BaseEntity
{
    public Guid DepartmentId { get; set; }

    public Department Department { get; set; } = null!;

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }

}
