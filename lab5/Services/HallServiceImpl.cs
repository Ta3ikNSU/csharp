using lab5.Model;
using lab5.Services.Interfaces;

namespace lab5.Services;

public class HallServiceImpl : HallService
{
    private readonly Dictionary<int, int> ContendersCounter;
    private readonly ILogger log;
    private readonly IServiceScopeFactory ScopeFactory;

    public HallServiceImpl(IServiceScopeFactory scopeFactory, ILogger<HallServiceImpl> logger)
    {
        ScopeFactory = scopeFactory;
        log = logger;
        ContendersCounter = new Dictionary<int, int>();
    }

    public string? getNextContender(int attemp_number)
    {
        using var scope = ScopeFactory.CreateScope();
        var AttemptContext = scope.ServiceProvider.GetRequiredService<AttemptContext>();

        if (!ContendersCounter.ContainsKey(attemp_number)) ContendersCounter.Add(attemp_number, 1);

        var currentNumber = ContendersCounter[attemp_number];
        if (currentNumber == 100) return null;
        // log.LogInformation("attemp_number : {}, currentNumber : {}", attemp_number, currentNumber);
        ContendersCounter[attemp_number] = currentNumber + 1;
        return AttemptContext.Attempts
            .FirstOrDefault(dao => dao.NumberAttempt.Equals(attemp_number) &&
                                   dao.Number.Equals(currentNumber))?.Name;
    }

    public int getHusbandRating(int attemp_number)
    {
        using var scope = ScopeFactory.CreateScope();
        var AttemptContext = scope.ServiceProvider.GetRequiredService<AttemptContext>();
        var dao = AttemptContext.Attempts.FirstOrDefault(dao =>
            dao.NumberAttempt.Equals(attemp_number) && dao.Number.Equals(-1));
        if (dao == null)
            return -1;
        return dao.Rating;
    }
}