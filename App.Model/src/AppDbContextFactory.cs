using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using App.Model;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer("aaaa");

        return new AppDbContext(optionsBuilder.Options);
    }
}