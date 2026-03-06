

using Domain.Entities.Base;

namespace Domain.Entities.Departments;

public class Department:BaseEntity
{

    public string Name { get; set; } = null!;

    public string? ImageUrl { get; set; }

}


