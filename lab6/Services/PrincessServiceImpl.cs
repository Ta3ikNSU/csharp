using lab6.DTO;
using lab6.Model;
using lab6.Model.Strategies;
using lab6.Services.Interfaces;

namespace lab6.Services;

public class PrincessServiceImpl : IHostedService
{
    private readonly IHostApplicationLifetime _appLifetime;

    private readonly ILogger _log;

    private readonly IServiceScopeFactory _scopeFactory;

    private readonly ContendersService _contendersService;

    public PrincessServiceImpl(
        IHostApplicationLifetime appLifetime,
        IServiceScopeFactory scopeFactory,
        ILogger<PrincessServiceImpl> logger,
        ContendersService contendersService)
    {
        _appLifetime = appLifetime;
        _scopeFactory = scopeFactory;
        _log = logger;
        _contendersService = contendersService;
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
        using var scope = _scopeFactory.CreateScope();
        var attemptContext = scope.ServiceProvider.GetRequiredService<AttemptContext>();
        
        for (var attempNumber = 1; attempNumber <= Constants.CountAttempts; attempNumber++)
        {
            var princess = new Princess(new SkipStrategy(4));
            var resultRating = 10;
            while (true)
            {
                GetNextContender(attempNumber);
                var contender = new ContenderDTO("eewfwef");
                while (_contendersService.isEmpty())
                {
                    // log.LogInformation("Queue is empty");
                    Thread.Sleep(1000);
                }
                _log.LogInformation("Queue not empty");
                if (contender.Name != null &&
                    !princess.SelectHusband(new Contender(contender.Name), attempNumber)) continue;
                var bestContender = princess.GetBestContender();
                if (bestContender != null)
                {
                    var attemptDao = attemptContext.Attempts.First(dao => dao.NumberAttempt.Equals(attempNumber) &&
                                                                          dao.Name.Equals(bestContender.Name));
                    resultRating = attemptDao.Rating > 50 ? attemptDao.Rating : 0;
                    attemptContext.SaveChanges();
                }

                break;
            }

            _log.LogInformation("For attemp_number : {} princess hapiness is : {}", attempNumber, resultRating);
        }
    }

    private static void GetNextContender(int attempNumber)
    {
        var hallUrlNext = "/hall/" + attempNumber + "/next";
        RestTemplate.PostWithNoResult(hallUrlNext, null).Wait();
    }
}