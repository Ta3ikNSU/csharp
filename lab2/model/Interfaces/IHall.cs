using System.Collections;

namespace lab2.model.Interfaces;

public interface IHall : IEnumerable
{
    public bool IsHallEmpty();

    public IContender GetNextContender();

    public Queue<IContender> GetContenders();
}