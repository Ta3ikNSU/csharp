using lab6.Model.Strategies;

namespace lab6.Model;

public class Princess
{
    private readonly IStrategy _strategy;

    public Princess(IStrategy strategy)
    {
        _strategy = strategy;
    }

    private Contender? BestContender
    {
        get => _strategy.BestContender();
    }

    public bool SelectHusband(Contender contender, int attemptNumber)
    {
        return _strategy.SelectStrategy(contender, attemptNumber);
    }

    public Contender? GetBestContender()
    {
        return BestContender;
    }
}
