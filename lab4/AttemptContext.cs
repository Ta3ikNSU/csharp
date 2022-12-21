using Microsoft.EntityFrameworkCore;

namespace lab4;

public sealed class AttemptContext : DbContext
{
    public DbSet<ChoiceAttemptDao> Attempts { get; set; }

    public AttemptContext()
    {
        //Database.EnsureCreated();
    }
    
    public AttemptContext(DbContextOptions<AttemptContext> options) : base(options)
    {
        this.Database.MigrateAsync();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChoiceAttemptDao>(builder =>
        {
            builder.ToTable("Attempts");
            builder.HasKey(dao => dao.Id);
            builder.Property(dao => dao.Number).IsRequired().HasComment("�����, ������� ���������� ���������� � ���������");
            builder.Property(dao => dao.Rating).IsRequired().HasComment("������� �����������");
            builder.Property(dao => dao.Name).IsRequired().HasComment("��� �����������");
            builder.Property(dao => dao.Patronymic).IsRequired().HasComment("������� �����������");
        });
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost:5432;Database=csharpdb;Username=postgres;Password=1234");
    }
}