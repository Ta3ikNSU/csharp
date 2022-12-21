using lab5.DTO;
using lab5.Model;
using lab5.Model.Strategies;
using Newtonsoft.Json;

namespace lab5.Services;

public class PrincessServiceImpl : IHostedService
{
    private readonly IHostApplicationLifetime _appLifetime;

    private Princess princess;

    private readonly IServiceScopeFactory ScopeFactory;
    
    public PrincessServiceImpl(IHostApplicationLifetime appLifetime, IServiceScopeFactory scopeFactory)
    {
        _appLifetime = appLifetime;
        princess = new Princess(new SkipStrategy(4));
        ScopeFactory = scopeFactory;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _appLifetime.ApplicationStarted.Register(OnStarted);
        return Task.CompletedTask;
    }

    private void OnStarted()
    {
        using var scope = ScopeFactory.CreateScope();
        var AttemptContext = scope.ServiceProvider.GetRequiredService<AttemptContext>();
        
        int attemp_number = 1;
        while (true)
        {
            ContenderDTO contender = getNextContender(attemp_number);
            
            if (contender != null && 
                contender.name != null &&
                !princess.SelectHusband(new Contender(contender.name), attemp_number))
            {
                continue;
            }
            
            if (contender.name == null)
            {
                var bestContender = princess.GetBestContender();
                if (bestContender != null)
                {
                    var attemptDao = AttemptContext.Attempts.First(dao => dao.NumberAttempt.Equals(attemp_number) &&
                                                                          dao.Name.Equals(bestContender.Name));
                    attemptDao.Number = -1;
                    AttemptContext.SaveChanges();
                }
                break;
            }
        }
    }

    private ContenderDTO getNextContender(int attemp_number)
    {
        String hallUrlNext = "http://127.0.0.1:5188/hall/{attemp_number}/next";
        var client = new HttpClient();
        var uri = new Uri(hallUrlNext.Replace("{attemp_number}", attemp_number.ToString()));
        var response = client.PostAsync(uri, null);
        using var sr = new StreamReader(response.Result.Content.ReadAsStream());
        using var jtr = new JsonTextReader(sr);
        return new JsonSerializer().Deserialize<ContenderDTO>(jtr);
    }
    
    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}