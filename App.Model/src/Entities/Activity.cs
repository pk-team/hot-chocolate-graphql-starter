namespace App.Model;

public class Activity : EntityBase {
    public string Title { get; set; } = "";
    public string? Note { get; set; }
    public DateTime Date { get;set; }
    public int DurationMinutes { get;set; }

    public ICollection<Todo> Todos { get; set;} = new List<Todo>();
}