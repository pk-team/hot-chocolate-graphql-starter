using App.Model;
using Microsoft.EntityFrameworkCore;

namespace App.Web;

public class Query {

    ///<summary>
    /// Returns application configured title
    ///</summary>
    public string AppTitle([Service] IConfiguration config) => config["AppTitle"] ?? "";

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Todo> GetTodos(
        AppDbContext context
    ) => context.Todos;

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Activity> GetActivities(
        AppDbContext context
    ) => context.Activities;
}