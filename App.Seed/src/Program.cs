// See https://aka.ms/new-console-template for more information
using System.Reflection;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

args.ToList().ForEach(a => Console.WriteLine(a));
var connection = args.Length > 0 ? args[0] : "";
var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
optionsBuilder.UseSqlServer(connection);
var context = new AppDbContext(optionsBuilder.Options);

// migrate
context.Database.Migrate();

// todos
var todos = new List<Todo> {
    new Todo{ 
        Title = "Create solution and projects", 
        DueDate = new DateTime(2023,1,5),
        Acivities = new List<Activity> {
            new Activity { Title = "Create solution App.Server, App.Model, App.Service", Date = new DateTime(2023,1,5), DurationMinutes = 120 },
            new Activity { Title = "Setup git repo", Date = new DateTime(2023,1,5), DurationMinutes = 30 },
        }
    },
    new Todo{ 
        Title = "Setup DbContext and initial entities", 
        DueDate = new DateTime(2023,1,6),
        Acivities = new List<Activity> {
            new Activity { Title = "Setup AppDbContext with fluent api", Date = new DateTime(2023,1,6), DurationMinutes = 60 },
        }
    },
    new Todo{ 
        Title = "Setup Graphql Server", 
        DueDate = new DateTime(2023,1,7),
        Acivities = new List<Activity> {
            new Activity { Title = "Add hotchoclate nuget package to app.model, app.server", Date = new DateTime(2023,1,7), DurationMinutes = 60 },
            new Activity { Title = "Add root query", Date = new DateTime(2023,1,7), DurationMinutes = 90 },
        }
    },
};

context.Todos.AddRange(todos);
context.SaveChanges();







