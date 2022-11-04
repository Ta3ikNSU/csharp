using Microsoft.EntityFrameworkCore;

namespace lab4;

public class AttemptContext : DbContext
{
    public DbSet<ChoiceAttemptDao> Attempts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost:3000;Database=csharpdb;Username=postgres;Password=1234");
    }
}