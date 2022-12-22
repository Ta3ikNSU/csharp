using Microsoft.EntityFrameworkCore;

namespace lab6.Model;

public sealed class AttemptContext : DbContext
{
    public AttemptContext(DbContextOptions<AttemptContext> options) : base(options)
    {
    }

    public DbSet<ChoiceAttemptDao> Attempts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChoiceAttemptDao>(builder =>
        {
            builder.ToTable("Attempts");
            builder.HasKey(dao => dao.Id);
            builder.Property(dao => dao.Number).IsRequired();
            builder.Property(dao => dao.Rating).IsRequired();
            builder.Property(dao => dao.Name).IsRequired();
        });
    }
}