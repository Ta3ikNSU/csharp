using Microsoft.EntityFrameworkCore;

namespace lab4;

public sealed class AttemptContext : DbContext
{
    public DbSet<ChoiceAttemptDao> Attempts { get; set; }

    public AttemptContext()
    {
        Database.EnsureCreated();
    }
    
    public AttemptContext(DbContextOptions<AttemptContext> options) : base(options)
    {
    }
    
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<ChoiceAttemptDao>(builder =>
    //     {
    //         builder.ToTable("Attempts");
    //         builder.HasKey(dao => dao.Id);
    //         builder.Property(dao => dao.Number).IsRequired().HasComment("Номер, которым претендент отправится к принцессе");
    //         builder.Property(dao => dao.Rating).IsRequired().HasComment("Рейтинг претендента");
    //         builder.Property(dao => dao.Name).IsRequired().HasComment("Имя претендента");
    //         builder.Property(dao => dao.Patronymic).IsRequired().HasComment("Фамилия претендента");
    //     });
    // }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost:5432;Database=csharpdb;Username=postgres;Password=1234");
    }
}