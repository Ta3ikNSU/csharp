using lab2.model.Interfaces;

namespace lab2.model;

public class Princess : IPrincess
{
    private readonly IFriend _friend;
    private IContender? _bestOption;

    private int _countSkipContenders = 4;

    public Princess(IFriend friend)
    {
        _friend = friend;
    }

    public bool SelectHusband(IContender contender)
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

    IContender? IPrincess.BestContender
    {
        get => _bestOption;
        set => _bestOption = value;
    }
}