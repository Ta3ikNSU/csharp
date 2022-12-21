using lab5.DTO;
using lab5.Services;

namespace lab5.Model.Strategies;

public class SkipStrategy : IStrategy
{
    private Contender? _bestOption;
    private int _countSkipContenders;

    public SkipStrategy(int countSkipContenders)
    {
        _countSkipContenders = countSkipContenders;
    }

    public bool SelectStrategy(Contender contender, int attemp_number)
    {
        if (_bestOption == null)
        {
            _bestOption = contender;
        }
        else
        {
            var friendUrl = "/friend/ " + attemp_number + "/compare";

            var contenderDto = RestTemplate
                .Post<ContenderDTO>(friendUrl, new PairContenderNameDTO(_bestOption.Name, contender.Name)).Result;

            if (contenderDto.name != null && !contenderDto.name.Equals(_bestOption.Name))
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

    public Task<bool> SelectStrategy(ContenderDTO contender, int attemp_number)
    {
        throw new NotImplementedException();
    }
}