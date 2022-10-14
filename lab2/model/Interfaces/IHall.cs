namespace lab2.model.Interfaces;

public interface IHall
{
    public bool IsHallEmpty();

    public IContender GetNextContender();

    public Queue<IContender> GetContenders();
}