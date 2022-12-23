using lab6.DTO;
using lab6.Services;

namespace lab6.Model.Strategies;

public class SkipStrategy : IStrategy
{
    private Contender? _bestOption;
    private int _countSkipContenders;

    public SkipStrategy(int countSkipContenders)
    {
        _countSkipContenders = countSkipContenders;
    }

    public bool SelectStrategy(Contender contender, int attempNumber)
    {
        if (_bestOption == null)
        {
            _bestOption = contender;
        }
        else
        {
            var friendUrl = "/friend/ " + attempNumber + "/compare";

            var contenderDto = RestTemplate
                .Post<ContenderDTO>(friendUrl, new PairContenderNameDTO(_bestOption.Name, contender.Name)).Result;

            if (contenderDto.Name != null && !contenderDto.Name.Equals(_bestOption.Name))
            {
                _bestOption = contender;
                if (_countSkipContenders == 0) return true;
            }
        }

        if (_countSkipContenders > 0)
            _countSkipContenders--;
        return false;
    }

    public Contender BestContender()
    {
        return _bestOption;
    }

    public Task<bool> SelectStrategy(ContenderDTO contender, int attempNumber)
    {
        throw new NotImplementedException();
    }
}