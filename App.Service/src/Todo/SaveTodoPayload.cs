namespace App.Service;

public class SaveTodoPayload : MutationPayload {
    public Todo? Todo { get; set; }    
}
