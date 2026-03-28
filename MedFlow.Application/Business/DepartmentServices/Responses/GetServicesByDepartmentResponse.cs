
namespace Application.Business.DepartmentServices.Responses;

public class GetServicesByDepartmentResponse
{
    public Guid DepartmentServiceId { get; set; }

    public string ServiceName { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public decimal Price { get; set; }

    public bool IsActive { get; set; }
}
