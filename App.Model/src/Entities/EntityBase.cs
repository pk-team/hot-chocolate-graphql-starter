namespace App.Model;

public class EntityBase {
    public Guid Id { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? RemovedAt { get; set; }
}