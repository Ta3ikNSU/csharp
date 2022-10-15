using System.Collections;
using lab2.Exception;
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
        if (_contenders.Count > 0)
        {
            return _contenders.Dequeue();
        }
        throw new HallEmptyException();
        
    }

    public Queue<IContender> GetContenders()
    {
        return _contenders;
    }

    public IEnumerator GetEnumerator()
    {
        return _contenders.GetEnumerator();
    }
}
