using lab6.DTO;
using lab6.Model;
using lab6.Services.Interfaces;
using MassTransit;

namespace lab6.Services;

public class HallServiceImplWithProducer : HallService
{
    private readonly Dictionary<int, int> _contendersCounter;
    private readonly ILogger _log;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IBus _bus;
    
    public HallServiceImplWithProducer(IServiceScopeFactory scopeFactory, ILogger<HallServiceImplWithProducer> logger, IBus bus)
    {
        _scopeFactory = scopeFactory;
        _log = logger;
        _bus = bus;
        _contendersCounter = new Dictionary<int, int>();
    }

    public string? getNextContender(int attemp_number)
    {
        using var scope = _scopeFactory.CreateScope();
        var attemptContext = scope.ServiceProvider.GetRequiredService<AttemptContext>();

        if (!_contendersCounter.ContainsKey(attemp_number)) _contendersCounter.Add(attemp_number, 1);

        var currentNumber = _contendersCounter[attemp_number];
        if (currentNumber == 100) return null;
        _contendersCounter[attemp_number] = currentNumber + 1;
        string? contenderName =  attemptContext.Attempts
            .FirstOrDefault(dao => dao.NumberAttempt.Equals(attemp_number) &&
                                   dao.Number.Equals(currentNumber))?.Name;
        _log.LogInformation("attemp_number : {}, currentNumber : {}, contenderName : {}", attemp_number, currentNumber, contenderName);
        _bus.Publish(new ContenderDTO(contenderName)).Wait();
        _log.LogInformation("success publish contenderName : {}", contenderName);
        return null;
    }

    public int getHusbandRating(int attemp_number)
    {
        using var scope = _scopeFactory.CreateScope();
        var attemptContext = scope.ServiceProvider.GetRequiredService<AttemptContext>();
        var dao = attemptContext.Attempts.FirstOrDefault(dao =>
            dao.NumberAttempt.Equals(attemp_number) && dao.Number.Equals(-1));
        if (dao == null)
            return -1;
        return dao.Rating;
    }
}