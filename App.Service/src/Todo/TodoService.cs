using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using App.Model;
using Microsoft.EntityFrameworkCore;

namespace App.Service;

public class TodoService {

    private AppDbContext context;
    public TodoService(AppDbContext context) {
        this.context = context;
    }

    public async Task<SaveTodoPayload> Save(TodoInput input) {
        var mutationPayload = new SaveTodoPayload();

        mutationPayload.Errors = await ValidateSaveTodo(input);
        if (mutationPayload.Errors.Any()) {
            return mutationPayload;
        }

        var todo = await context.Todos.FirstOrDefaultAsync(t => t.Id == input.Id);

        if (todo == null) {
            todo = new Todo();
            context.Todos.Add(todo);
        }
        todo.Title = input.Title;
        todo.DueDate = input.DueDate;

        await context.SaveChangesAsync();
        return new SaveTodoPayload {
            Todo = todo
        };
    }

    public async Task<List<Error>> ValidateSaveTodo(TodoInput input) {
        var errors = new List<Error>();

        Todo? existingTodo= null;

        if (input.Id is not null) {
            existingTodo = await context.Todos.FirstOrDefaultAsync(t => t.Id == input.Id);
            if (existingTodo is null) {
                errors.Add(new Error{ Message ="Todo not found" });    
                return errors;
            }
        }
        
        if (String.IsNullOrWhiteSpace(input.Title))  {
            errors.Add(new Error{ Message ="Title required" });
        }

        return errors;
    }
}