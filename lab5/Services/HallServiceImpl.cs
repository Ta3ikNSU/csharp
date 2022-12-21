using lab5.Services.Interfaces;

namespace lab5.Services;

public class HallServiceImpl : HallService
{
    private readonly IServiceScopeFactory ScopeFactory;

    private Dictionary<int, int> ContendersCounter;

    public HallServiceImpl(IServiceScopeFactory scopeFactory)
    {
        ScopeFactory = scopeFactory;
        ContendersCounter = new Dictionary<int, int>();
    }
    
    public string? getNextContender(int attemp_number)
    {
        using var scope = ScopeFactory.CreateScope();
        var AttemptContext = scope.ServiceProvider.GetRequiredService<AttemptContext>();

        if (!ContendersCounter.ContainsKey(attemp_number))
        {
            Console.WriteLine("attemp_number : " + attemp_number + " is Empty");
            ContendersCounter.Add(attemp_number, 1);
        }

        var currentNumber = ContendersCounter[attemp_number];
        if (currentNumber == 100)
        {
            return null;
        }
        Console.WriteLine("attemp_number : " + attemp_number + ", currentNumber : " + currentNumber);
        ContendersCounter[attemp_number] = currentNumber + 1;
        return AttemptContext.Attempts.First(
                dao => dao.NumberAttempt.Equals(attemp_number) &&
                       dao.Number.Equals(currentNumber))
            .Name;
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