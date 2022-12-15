using lab5.DTO;
using Newtonsoft.Json;

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
            String friendUrl = "http://127.0.0.1:5188/friend/{attemp_number}/compare";
            var client = new HttpClient();
            var uri = new Uri(friendUrl.Replace("{attemp_number}", attemp_number.ToString()));
            var response = client.PostAsJsonAsync(uri, new ContenderDTO(contender.Name));
            using var sr = new StreamReader(response.Result.Content.ReadAsStream());
            using var jtr = new JsonTextReader(sr);
            var contenderDto = new JsonSerializer().Deserialize<ContenderDTO>(jtr);
            
            if (!contenderDto.name.Equals(_bestOption.Name))
            {
                _bestOption = contender;
                if (_countSkipContenders == 0) return true;
            }
        }

        if (_countSkipContenders > 0)
            _countSkipContenders--;
        return false;
    }

    public Task<bool> SelectStrategy(ContenderDTO contender, int attemp_number)
    {
        throw new NotImplementedException();
    }

    public Contender BestContender()
    {
        return _bestOption;
    }
}