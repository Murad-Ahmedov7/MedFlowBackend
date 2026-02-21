namespace Domain.Entities;



public class BaseEntity
{
    public Guid Id { get; set; }                 
    public DateTime CreatedAt { get; set; }      
    public Guid? CreatedBy { get; set; }         
    public bool IsDeleted { get; set; }           
}