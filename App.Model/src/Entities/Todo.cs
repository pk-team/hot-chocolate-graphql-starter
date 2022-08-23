namespace App.Model;

public class Todo : EntityBase {
    public string Title { get; set; } = "";
    public DateTime? DueDate { get; set; }
    public ICollection<Activity> Acivities { get; set; } = new List<Activity>();
}