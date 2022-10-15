using lab2.model.Interfaces;

namespace lab2.model;

public class Princess : IPrincess
{
    private readonly IStrategy _strategy;
    
    public Princess(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public bool SelectHusband(IContender contender)
    {
        return _strategy.SelectStrategy(contender);
    }

    IContender? IPrincess.BestContender
    {
        get => _strategy.BestContender();
        set => throw new NotImplementedException();
    }
}
