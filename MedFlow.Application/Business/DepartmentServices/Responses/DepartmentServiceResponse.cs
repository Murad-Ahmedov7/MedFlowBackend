
namespace Application.Business.DepartmentServices.Responses;

public class DepartmentServiceResponse
{
    public Guid Id { get; set; }

    public Guid DepartmentId { get; set; }

    public Guid ServiceId { get; set; }

    public decimal Price { get; set; }

    public bool IsActive { get; set; }
}
