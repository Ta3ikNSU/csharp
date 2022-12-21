using lab5.DTO;
using lab5.Model;
using lab5.Model.Strategies;

namespace lab5.Services;

public class PrincessServiceImpl : IHostedService
{
    private readonly IHostApplicationLifetime _appLifetime;

    private readonly ILogger log;

    private readonly IServiceScopeFactory ScopeFactory;

    public PrincessServiceImpl(IHostApplicationLifetime appLifetime, IServiceScopeFactory scopeFactory,
        ILogger<PrincessServiceImpl> logger)
    {
        _appLifetime = appLifetime;
        ScopeFactory = scopeFactory;
        log = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _appLifetime.ApplicationStarted.Register(OnStarted);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private void OnStarted()
    {
        using var scope = ScopeFactory.CreateScope();
        var AttemptContext = scope.ServiceProvider.GetRequiredService<AttemptContext>();
        for (var attemp_number = 1; attemp_number <= Constants.CountAttempts; attemp_number++)
        {
            var princess = new Princess(new SkipStrategy(4));
            var resultRating = 10;
            while (true)
            {
                var contender = getNextContender(attemp_number);
                if (contender.name != null &&
                    !princess.SelectHusband(new Contender(contender.name), attemp_number)) continue;
                var bestContender = princess.GetBestContender();
                if (bestContender != null)
                {
                    var attemptDao = AttemptContext.Attempts.First(dao => dao.NumberAttempt.Equals(attemp_number) &&
                                                                          dao.Name.Equals(bestContender.Name));
                    resultRating = attemptDao.Rating > 50 ? attemptDao.Rating : 0;
                    AttemptContext.SaveChanges();
                }

                break;
            }

            log.LogInformation("For attemp_number : {} princess hapiness is : {}", attemp_number, resultRating);
        }
    }

    private static ContenderDTO getNextContender(int attemp_number)
    {
        var hallUrlNext = "/hall/" + attemp_number + "/next";
        return RestTemplate.Post<ContenderDTO>(hallUrlNext, null).Result;
    }
}