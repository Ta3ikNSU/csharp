using lab6.DTO;
using lab6.Model;
using lab6.Model.Strategies;
using lab6.Services.Interfaces;

namespace lab6.Services;

public class PrincessServiceImpl : IHostedService
{
    private readonly IHostApplicationLifetime _appLifetime;

    private readonly ILogger log;

    private readonly IServiceScopeFactory ScopeFactory;

    private readonly ContendersService ContendersService;

    public PrincessServiceImpl(
        IHostApplicationLifetime appLifetime,
        IServiceScopeFactory scopeFactory,
        ILogger<PrincessServiceImpl> logger,
        ContendersService contendersService)
    {
        _appLifetime = appLifetime;
        ScopeFactory = scopeFactory;
        log = logger;
        ContendersService = contendersService;
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
                getNextContender(attemp_number);
                var contender = new ContenderDTO("eewfwef");
                while (ContendersService.isEmpty())
                {
                    // log.LogInformation("Queue is empty");
                    Thread.Sleep(1000);
                }
                log.LogInformation("Queue not empty");
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

    private static void getNextContender(int attemp_number)
    {
        var hallUrlNext = "/hall/" + attemp_number + "/next";
        RestTemplate.PostWithNoResult(hallUrlNext, null).Wait();
    }
}