namespace App.Service;

public class TodoInput {
    public Guid? Id { get; set; }
    public string Title { get; set; } = "";
    public DateTime? DueDate { get; set; }
}