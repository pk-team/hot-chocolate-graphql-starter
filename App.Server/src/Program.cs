#nullable disable

using App.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<IConfiguration>(builder.Configuration)
    .AddScoped<TodoService>();

builder.Services.AddDbContext<AppDbContext>(op => {
    var connection = builder.Configuration.GetConnectionString("Default");
    op.UseSqlServer(connection);
});

builder.Services
    .AddGraphQLServer()
    // inject scoped DbContext into resolvers
    .RegisterDbContext<AppDbContext>()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddProjections()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .AddTypeConverter<DateTime, DateTimeOffset>(
        t => t.Kind == DateTimeKind.Unspecified
            ? DateTime.SpecifyKind(t, DateTimeKind.Utc)
            : t
    );

builder.Services.AddCors(options => options.AddDefaultPolicy(
 builder => builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()
));

var app = builder.Build();

app.UseCors();
app.MapGraphQL();
app.Run();
