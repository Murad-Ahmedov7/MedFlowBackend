using Domain.Entities.Base;

namespace Domain.Entities.Demo;


public class Category : BaseEntity
{
    public string Name { get; set; } = null!;    
}