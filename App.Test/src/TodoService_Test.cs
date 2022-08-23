using System.Globalization;
using System.Windows.Markup;

namespace App.Test;

public class TodoService_Test : TestBase {
    [Fact]
    public async void Add_Update_Todo() {
        var context = GetAppDbContext();
        var service = new TodoService(context);

        var entries = new List<(string title, DateTime? due)> {
            ("Write Code", DateTime.Now.AddDays(10)),
            ("Refactor", null),
        };

        Guid? todoId = null;

        foreach (var entry in entries) {
            var payload = await service.Save(new TodoInput { Id = todoId, Title = entry.title, DueDate = entry.due });
            todoId = payload.Todo?.Id ?? new Guid();
            var todo = await context.Todos.FirstOrDefaultAsync(t => t.Id == todoId);

            Assert.NotNull(todo);
            Assert.Equal(entry.title, todo?.Title);
            Assert.Equal(entry.due, todo?.DueDate);
        };

        var count = await context.Todos.CountAsync();
        Assert.Equal(1, count);
    }

    [Fact]
    public async Task Todo_Title_Requied() {
        var context = GetAppDbContext();
        var service = new TodoService(context);

        var input = new TodoInput { Title = "" };
        // act
        var paylaod = await service.Save(input);

        var errorCount = paylaod.Errors.Count();
        Assert.True(errorCount == 1);
    }
}