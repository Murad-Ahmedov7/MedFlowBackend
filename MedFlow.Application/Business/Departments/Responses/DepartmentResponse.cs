
namespace Application.Business.Departments.Responses;

public class DepartmentResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }

    public DateTime CreatedAt { get; set; }
}

