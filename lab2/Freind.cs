using lab2.Interfaces;

namespace lab2;

public class Friend : IFriend
{
    private readonly Dictionary<IContender, int> _contendersRating;

    public Friend(IReadOnlyList<IContender> contenders)
    {
        _contendersRating = new Dictionary<IContender, int>();
        for (var i = 0; i < contenders.Count; i++) _contendersRating.Add(contenders[i], i + 1);
    }

    public bool CompareContenders(IContender contenderNameFirst, IContender contenderNameSecond)
    {
        return _contendersRating[contenderNameFirst] > _contendersRating[contenderNameSecond];
    }
}