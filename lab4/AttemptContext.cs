using lab4.DAO;
using Microsoft.EntityFrameworkCore;

namespace lab4;

public sealed class AttemptContext : DbContext
{
    public DbSet<ChoiceAttemptDao> Attempts { get; set; }
    public DbSet<ContenderDao> Contenders { get; set; }

    public AttemptContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost:5432;Database=csharpdb;Username=postgres;Password=1234");
    }
}