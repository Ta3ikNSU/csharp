
namespace lab1;

public class Princess
{
    private readonly Hall _hall;
    
    private Contender? _bestOption;

    private int _countSkipContenders = ;

    public Princess(Hall hall)
    {
        _hall = hall;
    }
    
    public bool SelectHusband(Contender contender)
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

    public Contender? GetBestContender()
    {
        return _bestOption;
    }
}