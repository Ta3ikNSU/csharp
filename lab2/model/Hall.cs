using lab2.model.Interfaces;

namespace lab2.model;

public class Hall : IHall
{
    private readonly Queue<IContender> _contenders;

    public Hall(IContenderGenerator contenderGenerator)
    {
        _contenders = new Queue<IContender>(contenderGenerator.GetContenders().OrderBy(_ => new Random().Next()));
    }

    public bool IsHallEmpty()
    {
        return _contenders.Count == 0;
    }

    public IContender GetNextContender()
    {
        return _contenders.Dequeue();
    }

    public Queue<IContender> GetContenders()
    {
        return _contenders;
    }

    public IContender GetCont()
    {
        return _contenders.Dequeue();
    }
}