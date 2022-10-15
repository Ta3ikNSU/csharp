namespace lab2.model.Interfaces;

public interface IStrategy
{
    public bool SelectStrategy(IContender contender);
    public IContender BestContender();
}
