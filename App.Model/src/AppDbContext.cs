using Microsoft.EntityFrameworkCore;

namespace App.Model;

public class AppDbContext : DbContext {

    public DbSet<Todo> Todos => Set<Todo>();
    public DbSet<Activity> Activities => Set<Activity>();
    public AppDbContext(DbContextOptions options) : base(options) {}
    protected override void OnConfiguring(DbContextOptionsBuilder builder) {}
    protected override void OnModelCreating(ModelBuilder builder) {         
        var taskBuilder = builder.Entity<Todo>();
        taskBuilder.ToTable("Todo");        
        taskBuilder.Property(t => t.Id).HasMaxLength(36).ValueGeneratedOnAdd();
        taskBuilder.Property(t => t.Title).HasMaxLength(200);
        taskBuilder.HasIndex(t => t.Title);        

        var activityBuilder = builder.Entity<Activity>();
        activityBuilder.ToTable("Activity");        
        activityBuilder.Property(t => t.Id).HasMaxLength(36).ValueGeneratedOnAdd();
        activityBuilder.Property(t => t.Title).HasMaxLength(250);
        activityBuilder.HasIndex(t => t.Title);        
    }
}