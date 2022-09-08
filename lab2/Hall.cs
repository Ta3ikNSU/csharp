using lab2.Interfaces;

namespace lab2;

public class Hall : IHall
{
    private Queue<IContender> _contenders;
    private IFriend _friend;

    public Hall(IFriend friend, IEnumerable<IContender> contenders)
    {
        _contenders = new Queue<IContender>(contenders.OrderBy(_ => new Random().Next()));
        _friend = friend;
    }
    
    Queue<IContender> IHall.Contenders
    {
        get => _contenders;
        set => _contenders = value;
    }
    
    IFriend IHall.Friend
    {
        get => _friend;
        set => _friend = value;
    }
}