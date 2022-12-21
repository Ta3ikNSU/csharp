using lab5.Model.Strategies;

namespace lab5.Model;

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

    public bool SelectHusband(Contender contender, int attempt_number)
    {
        return _strategy.SelectStrategy(contender, attempt_number);
    }

    public Contender? GetBestContender()
    {
        return BestContender;
    }
}
