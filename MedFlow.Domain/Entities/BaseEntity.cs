namespace Domain.Entities;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public Guid CreatedBy { get; set; }

    public bool IsDeleted { get; set; } = false;
}
