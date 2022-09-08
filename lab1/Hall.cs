namespace lab1;

public class Hall
{
    private Queue<Contender> _contenders;
    private readonly Friend _friend;
    public Hall(Friend friend, List<Contender> contenders)
    {
        _contenders = new Queue<Contender>(contenders.OrderBy(_ => new Random().Next()));
        _friend = friend;
    }

    public Friend GetFriend()
    {
        return _friend;
    }

    public Contender GetNextContender()
    {
        return _contenders.Dequeue();
    }

    public bool IsHallEmpty()
    {
        return _contenders.Count == 0;
    }
}