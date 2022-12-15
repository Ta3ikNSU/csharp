using lab5.Exception;

namespace lab5.Services;

public class FriendServiceImpl : FriendService
{
    private readonly IServiceScopeFactory ScopeFactory;
    
    public FriendServiceImpl(IServiceScopeFactory scopeFactory)
    {
        ScopeFactory = scopeFactory;
    }
    
    public string? compareContenders(string? name1, string? name2, int attempNumber)
    {
        using var scope = ScopeFactory.CreateScope();
        var AttemptContext = scope.ServiceProvider.GetRequiredService<AttemptContext>();
        
        Console.WriteLine("name1 : " + name1 + ", name2 : " + name2);
        
        var firstRating = AttemptContext.Attempts.First(dao => dao.Name.Equals(name1)).Number;
        var secondRating = AttemptContext.Attempts.First(dao => dao.Name.Equals(name2)).Number;
        
        if (firstRating == secondRating && !name1.Equals(name2))
        {
            throw new GenerateEnvironException("Во время генерации что-то пошло не так");
        }
        Console.WriteLine("firstRating : " + firstRating + ", secondRating : " + secondRating);
        return firstRating > secondRating ? name1 : name2;
    }
}