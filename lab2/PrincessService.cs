using System.Text;
using lab2.model.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using static System.DateTime;

namespace lab2;

public class PrincessService : IHostedService
{
    private readonly IHostApplicationLifetime _appLifetime;
    private readonly IFriend _friend;
    private readonly IHall _hall;

    private readonly ILogger _logger;
    private readonly IPrincess _princess;

    public PrincessService(IFriend friend, IHall hall, IPrincess princess, ILogger<PrincessService> logger,
        IHostApplicationLifetime appLifetime)
    {
        _friend = friend;
        _hall = hall;
        _princess = princess;
        _logger = logger;
        _appLifetime = appLifetime;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _appLifetime.ApplicationStarted.Register(OnStarted);
        _appLifetime.ApplicationStopping.Register(OnStopping);
        _appLifetime.ApplicationStopped.Register(OnStopped);

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private static void WriteOut(IEnumerable<IContender> contenders, int result)
    {
        var fileName = Now.ToLongTimeString().Replace(":", "_") + ".txt";
        using var fs = File.Create(fileName);
        foreach (var contenderName in contenders!.Select(contender =>
                     new UTF8Encoding(true).GetBytes(contender.GetFullName() + '\n')))
            fs.Write(contenderName, 0, contenderName.Length);

        var resultString = new UTF8Encoding(true).GetBytes(result.ToString() + '\n');
        fs.Write(resultString, 0, resultString.Length);
    }

    private void OnStarted()
    {
        _logger.LogInformation("Application start working");
        var result = 10;
        var contenders = _hall.GetContenders();
        foreach (IContender contender in _hall)
        {
            if (!_princess.SelectHusband(contender)) continue;
            var bestContender = _princess.GetBestContender();
            if (contenders == null) continue;
            result = _friend.GetRank(bestContender!) > 50 ? _friend.GetRank(bestContender!) : 0;
            break;
        }

        if (contenders != null) WriteOut(contenders, result);

        _logger.LogInformation("Princess select (or not select) husband. Happiness rating is : {result}", result);

        _appLifetime.StopApplication();
    }

    private void OnStopping()
    {
        _logger.LogInformation("Application stopping");
    }

    private void OnStopped()
    {
        _logger.LogInformation("Application successfully stopped");
    }
}
