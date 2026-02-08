namespace Application.Business.Categories.Responses;

public class CreateCategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
