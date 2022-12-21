using lab5.Model;
using lab5.Services.Interfaces;

namespace lab5.Services;

public class AttemptsGeneratorImpl : AttemptsGenerator
{
    private readonly ContenderGenerator ContenderGenerator;

    private readonly ILogger Logger;
    private readonly IServiceScopeFactory ScopeFactory;

    public AttemptsGeneratorImpl(ContenderGenerator contenderGenerator, IServiceScopeFactory scopeFactory,
        ILogger<AttemptsGeneratorImpl> logger)
    {
        ScopeFactory = scopeFactory;
        Logger = logger;
        ContenderGenerator = contenderGenerator;
    }

    public void GenerateEnvironment()
    {
        using var scope = ScopeFactory.CreateScope();
        var AttemptContext = scope.ServiceProvider.GetRequiredService<AttemptContext>();

        CleanContenders(AttemptContext);
        GenerateConteders(AttemptContext);
        AttemptContext.SaveChanges();
    }

    private void CleanContenders(AttemptContext AttemptContext)
    {
        AttemptContext.Attempts.RemoveRange(AttemptContext.Attempts);
    }

    private void GenerateConteders(AttemptContext AttemptContext)
    {
        for (var i = 1; i <= Constants.CountAttempts; i++)
        {
            var queue = new Queue<int>(
                Enumerable.Range(1, Constants.CountOfContenders).OrderBy(_ => new Random().Next()));
            var rating = new Queue<int>(
                Enumerable.Range(1, Constants.CountOfContenders).OrderBy(_ => new Random().Next()));
            for (var contenderNumber = 0; contenderNumber < Constants.CountOfContenders; contenderNumber++)
            {
                var contender = ContenderGenerator.GenerateContender();
                var choiceAttempt = new ChoiceAttemptDao
                {
                    NumberAttempt = i,
                    Number = queue.Dequeue(),
                    Name = contender.Name,
                    Rating = rating.Dequeue()
                };
                AttemptContext.Attempts.Add(choiceAttempt);
            }
        }
    }
}