
using lab5.Model.Strategies;

namespace lab5.Model;

public class Princess {
    private readonly IStrategy _strategy;
    
    public Princess(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public bool SelectHusband(Contender contender, int attempt_number)
    {
        return _strategy.SelectStrategy(contender, attempt_number);
    }

    Contender BestContender
    {
        get => _strategy.BestContender();
        set => throw new NotImplementedException();
    }
    
    public Contender? GetBestContender()
    {
        return BestContender;
    }
}
