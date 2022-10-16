using lab2.model.Interfaces;

namespace lab2.model;

public class SkipStrategy : IStrategy
{
    private IContender? _bestOption;
    private int _countSkipContenders;

    private readonly IFriend _friend;

    public SkipStrategy(IFriend friend)
    {
        _friend = friend;
        _countSkipContenders = Constants.CountSkipContenders;
    }
    
    public SkipStrategy(IFriend friend, int countSkipContenders)
    {
        _friend = friend;
        _countSkipContenders = countSkipContenders;
    }

    public bool SelectStrategy(IContender contender)
    {
        if (_bestOption == null)
        {
            _bestOption = contender;
        }
        else
        {
            if (!_friend.CompareContenders(_bestOption, contender))
            {
                _bestOption = contender;
                if (_countSkipContenders == 0) return true;
            }
        }

        if (_countSkipContenders > 0)
            _countSkipContenders--;
        return false;
    }

    public IContender BestContender()
    {
        return _bestOption;
    }
}
