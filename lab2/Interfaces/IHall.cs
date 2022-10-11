namespace lab2.Interfaces;

public interface IHall
{
    public bool IsHallEmpty();

    public IContender GetNextContender();

    public Queue<IContender> GetContenders();
}