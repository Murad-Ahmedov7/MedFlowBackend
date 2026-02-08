namespace Application.Business.Categories.Responses;

public sealed class UpdateCategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
