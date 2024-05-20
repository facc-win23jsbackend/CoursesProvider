using Courses_WebAPI.Entities;
using Microsoft.EntityFrameworkCore;
namespace Courses_WebAPI.DataContexts;

public class DataContext : DbContext
{
    public DbSet<CoursesEntity> Courses { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoursesEntity>().ToContainer("Courses");
        modelBuilder.Entity<CoursesEntity>().HasPartitionKey(c => c.Id);
        modelBuilder.Entity<CoursesEntity>().OwnsOne(c => c.Prices);
        modelBuilder.Entity<CoursesEntity>().OwnsMany(c => c.Authors);
        modelBuilder.Entity<CoursesEntity>().OwnsOne(c => c.Content, content => content.OwnsMany(c => c.ProgramDetails));

    }
}
