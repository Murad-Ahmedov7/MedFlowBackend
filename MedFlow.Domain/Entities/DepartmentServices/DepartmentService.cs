
using Domain.Entities.Departments;
using Domain.Entities.Services;

namespace Domain.Entities.DepartmentServices;

public class DepartmentService
{
    public Guid Id { get; set; }

    public Guid DepartmentId { get; set; }

    public Guid ServiceId { get; set; }

    public decimal Price { get; set; }

    public bool IsActive { get; set; }

    public Department Department { get; set; } = null!;

    public Service Service { get; set; } = null!;
}