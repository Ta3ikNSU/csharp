using lab2.model.Interfaces;

namespace lab2.model;

public class ContenderGenerator : IContenderGenerator
{
    private readonly IList<IContender> _contenders = new List<IContender>();

    public ContenderGenerator()
    {
        for (var i = 0; i < Constants.CountOfContenders; i++) _contenders.Add(GenerateContender());
    }

    public IContender GenerateContender()
    {
        var name = Constants.GetRandomName();
        var patronymic =  Constants.GetRandomName() + "ович";
        return new Contender(name, patronymic);
    }

    public IList<IContender> GetContenders()
    {
        return _contenders;
    }
}