namespace lab1;

public class Princess
{
    private readonly Friend _friend;

    private Contender? _bestOption;

    private int _countSkipContenders = 4;

    public Princess(Friend friend)
    {
        _friend = friend;
    }

    public bool SelectHusband(Contender contender)
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

    public Contender? GetBestContender()
    {
        return _bestOption;
    }
}
