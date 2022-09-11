namespace lab2.Interfaces;

public interface IHall
{
    protected Queue<IContender> Contenders { get; set; }

    protected IFriend Friend { get; set; }

    public bool IsHallEmpty()
    {
        return Contenders.Count == 0;
    }

    public IContender GetNextContender()
    {
        return Contenders.Dequeue();
    }

    public IFriend GetFriend()
    {
        return Friend;
    }
}