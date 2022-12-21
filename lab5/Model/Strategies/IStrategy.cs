namespace lab5.Model.Strategies;

public interface IStrategy
{
    public bool SelectStrategy(Contender contender, int attemp_number);
    public Contender? BestContender();
}