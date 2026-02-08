namespace Application.Business.Categories.Responses;

public sealed class GetAllCategoriesResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
