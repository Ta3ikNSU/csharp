using System.Data.Entity;

namespace lab4;

public class AttemptContext : DbContext
{
    protected AttemptContext()
        : base("DbConnection")
    {
    }

    public DbSet<ChoiceAttempt> Attempts { get; set; }
}