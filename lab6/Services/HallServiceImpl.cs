using lab6.Model;
using lab6.Services.Interfaces;

namespace lab6.Services;

public class HallServiceImpl : HallService
{
    private readonly Dictionary<int, int> _contendersCounter;
    private readonly ILogger _log;
    private readonly IServiceScopeFactory _scopeFactory;

    public HallServiceImpl(IServiceScopeFactory scopeFactory, ILogger<HallServiceImpl> logger)
    {
        _scopeFactory = scopeFactory;
        _log = logger;
        _contendersCounter = new Dictionary<int, int>();
    }

    public string? getNextContender(int attemp_number)
    {
        using var scope = _scopeFactory.CreateScope();
        var AttemptContext = scope.ServiceProvider.GetRequiredService<AttemptContext>();

        if (!_contendersCounter.ContainsKey(attemp_number)) _contendersCounter.Add(attemp_number, 1);

        var currentNumber = _contendersCounter[attemp_number];
        if (currentNumber == 100) return null;
        _log.LogTrace("attemp_number : {}, currentNumber : {}", attemp_number, currentNumber);
        _contendersCounter[attemp_number] = currentNumber + 1;
        return AttemptContext.Attempts
            .FirstOrDefault(dao => dao.NumberAttempt.Equals(attemp_number) &&
                                   dao.Number.Equals(currentNumber))?.Name;
    }

    public int getHusbandRating(int attemp_number)
    {
        using var scope = _scopeFactory.CreateScope();
        var AttemptContext = scope.ServiceProvider.GetRequiredService<AttemptContext>();
        var dao = AttemptContext.Attempts.FirstOrDefault(dao =>
            dao.NumberAttempt.Equals(attemp_number) && dao.Number.Equals(-1));
        if (dao == null)
            return -1;
        return dao.Rating;
    }
}