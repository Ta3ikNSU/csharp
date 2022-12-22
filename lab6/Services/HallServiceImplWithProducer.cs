using lab6.DTO;
using lab6.Model;
using lab6.Services.Interfaces;
using MassTransit;

namespace lab6.Services;

public class HallServiceImplWithProducer : HallService
{
    private readonly Dictionary<int, int> ContendersCounter;
    private readonly ILogger log;
    private readonly IServiceScopeFactory ScopeFactory;
    private readonly IBus _bus;
    
    public HallServiceImplWithProducer(IServiceScopeFactory scopeFactory, ILogger<HallServiceImplWithProducer> logger, IBus bus)
    {
        ScopeFactory = scopeFactory;
        log = logger;
        _bus = bus;
        ContendersCounter = new Dictionary<int, int>();
    }

    public string? getNextContender(int attemp_number)
    {
        using var scope = ScopeFactory.CreateScope();
        var AttemptContext = scope.ServiceProvider.GetRequiredService<AttemptContext>();

        if (!ContendersCounter.ContainsKey(attemp_number)) ContendersCounter.Add(attemp_number, 1);

        var currentNumber = ContendersCounter[attemp_number];
        if (currentNumber == 100) return null;
        ContendersCounter[attemp_number] = currentNumber + 1;
        string? contenderName =  AttemptContext.Attempts
            .FirstOrDefault(dao => dao.NumberAttempt.Equals(attemp_number) &&
                                   dao.Number.Equals(currentNumber))?.Name;
        log.LogInformation("attemp_number : {}, currentNumber : {}, contenderName : {}", attemp_number, currentNumber, contenderName);
        _bus.Publish(new ContenderDTO(contenderName)).Wait();
        log.LogInformation("success publish contenderName : {}", contenderName);
        return null;
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