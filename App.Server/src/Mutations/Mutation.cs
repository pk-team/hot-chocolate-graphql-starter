
public class Mutation {

    ///<summary>
    /// Creates a Todo if ID is null, otherwise updates the Todo
    ///</summary>
    public async Task<SaveTodoPayload> SaveTodo
        ([Service] TodoService service,
        TodoInput input
    ) => await service.Save(input);
}