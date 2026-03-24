

namespace Application.Business.Services.Responses;
public class CreateServiceResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }

    public DateTime CreatedAt { get; set; }
}
