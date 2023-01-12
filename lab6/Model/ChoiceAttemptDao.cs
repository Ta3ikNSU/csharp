using Lombok.NET;

namespace lab6.Model;

[ToString]
public partial class ChoiceAttemptDao
{
    public long Id { get; set; }
    public int NumberAttempt { get; set; }

    public int Number { get; set; }

    public int Rating { get; set; }

    public string? Name { get; set; }
}