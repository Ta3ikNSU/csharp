using lab2.Interfaces;

namespace lab2;

public class ContenderGenerator : IContenderGenerator
{
    private const int CountOfContenders = 100;

    private readonly IList<IContender> _contenders = new List<IContender>();

    public ContenderGenerator()
    {
        for (var i = 0; i < CountOfContenders; i++) _contenders.Add(GenerateContender());
    }

    public IContender GenerateContender()
    {
        var name = Constants.NamesQueue.Dequeue();
        var patronymic = Constants.NamesQueue.Dequeue() + "ович";
        return new Contender(name, patronymic);
    }

    public IList<IContender> GetContenders()
    {
        return _contenders;
    }
}