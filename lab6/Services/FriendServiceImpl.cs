using lab6.Exception;
using lab6.Model;

namespace lab6.Services;

public class FriendServiceImpl : FriendService
{
    private readonly ILogger log;
    private readonly IServiceScopeFactory ScopeFactory;

    public FriendServiceImpl(IServiceScopeFactory scopeFactory, ILogger<FriendServiceImpl> logger)
    {
        ScopeFactory = scopeFactory;
        log = logger;
    }

    public string compareContenders(string name1, string name2, int attempNumber)
    {
        var methodName = "compareContenders()";
        using var scope = ScopeFactory.CreateScope();
        var attemptContext = scope.ServiceProvider.GetRequiredService<AttemptContext>();

        log.LogTrace("{}: name1 : {}, name2 : {}", methodName, name1, name2);

        var firstRating = attemptContext.Attempts
            .First(dao => dao.Name.Equals(name1) && dao.NumberAttempt.Equals(attempNumber)).Rating;
        var secondRating = attemptContext.Attempts
            .First(dao => dao.Name.Equals(name2) && dao.NumberAttempt.Equals(attempNumber)).Rating;

        if (firstRating == secondRating && !name1.Equals(name2))
        {
            log.LogError("{}: ({}:{}), ({}:{})", methodName, name1, firstRating, name2, secondRating);
            throw new GenerateEnvironException("Во время генерации что-то пошло не так");
        }

        return firstRating > secondRating ? name1 : name2;
    }
}