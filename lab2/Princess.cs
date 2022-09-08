using lab2.Interfaces;

namespace lab2;

public class Princess : IPrincess
{

    private int _countSkipContenders = 4;
    private IHall _hall;
    private IContender? _bestOption;

    public Princess(IHall hall)
    {
        _hall = hall;
    }
    
    public bool SelectHusband(IContender contender)
    {
        if (_bestOption == null)
        {
            _bestOption = contender;
        }
        else
        {
            if (!_hall.GetFriend().CompareContenders(_bestOption, contender))
            {
                _bestOption = contender;
                if (_countSkipContenders == 0)
                {
                    return true;
                }
            }
        }

        if(_countSkipContenders > 0) 
            _countSkipContenders--;
        return false;
    }
    
    IHall IPrincess.Hall
    {
        get => _hall;
        set => _hall = value;
    }

    IContender? IPrincess.BestContender
    {
        get => _bestOption;
        set => _bestOption = value;
    }
}