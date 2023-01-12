using lab6.Model;
using lab6.Services.Interfaces;

namespace lab6.Services;

public class AttemptsGeneratorImpl : AttemptsGenerator
{
    private readonly ContenderGenerator _contenderGenerator;

    private readonly ILogger _logger;
    private readonly IServiceScopeFactory _scopeFactory;

    public AttemptsGeneratorImpl(ContenderGenerator contenderGenerator, IServiceScopeFactory scopeFactory,
        ILogger<AttemptsGeneratorImpl> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
        _contenderGenerator = contenderGenerator;
    }

    public void GenerateEnvironment()
    {
        using var scope = _scopeFactory.CreateScope();
        var attemptContext = scope.ServiceProvider.GetRequiredService<AttemptContext>();

        CleanContenders(attemptContext);
        GenerateContenders(attemptContext);
        attemptContext.SaveChanges();
    }

    private void CleanContenders(AttemptContext attemptContext)
    {
        attemptContext.Attempts.RemoveRange(attemptContext.Attempts);
    }

    private void GenerateContenders(AttemptContext attemptContext)
    {
        for (var i = 1; i <= Constants.CountAttempts; i++)
        {
            var queue = new Queue<int>(
                Enumerable.Range(1, Constants.CountOfContenders).OrderBy(_ => new Random().Next()));
            var rating = new Queue<int>(
                Enumerable.Range(1, Constants.CountOfContenders).OrderBy(_ => new Random().Next()));
            for (var contenderNumber = 0; contenderNumber < Constants.CountOfContenders; contenderNumber++)
            {
                var contender = _contenderGenerator.GenerateContender();
                var choiceAttempt = new ChoiceAttemptDao
                {
                    NumberAttempt = i,
                    Number = queue.Dequeue(),
                    Name = contender.Name,
                    Rating = rating.Dequeue()
                };
                attemptContext.Attempts.Add(choiceAttempt);
            }
        }
    }
}