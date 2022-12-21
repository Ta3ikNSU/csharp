using Microsoft.EntityFrameworkCore;

namespace lab5;

public sealed class AttemptContext : DbContext
{
    public DbSet<ChoiceAttemptDao> Attempts { get; set; }

    public AttemptContext(DbContextOptions<AttemptContext> options) : base(options)
    {
        this.Database.Migrate();
    }
    
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