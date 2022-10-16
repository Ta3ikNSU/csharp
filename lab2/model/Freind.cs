using lab2.model.Interfaces;

namespace lab2.model;

public class Friend : IFriend
{
    private readonly Dictionary<IContender, int> _contendersRating;

    public Friend(IContenderGenerator contenderGenerator)
    {
        _contendersRating = new Dictionary<IContender, int>();
        var contenders = contenderGenerator.GetContenders();
        for (var i = 0; i < contenders.Count; i++) _contendersRating.Add(contenders[i], i + 1);
    }

    public bool CompareContenders(IContender contenderNameFirst, IContender contenderNameSecond)
    {
        return _contendersRating[contenderNameFirst] > _contendersRating[contenderNameSecond];
    }

    public int GetRank(IContender contender)
    {
        return _contendersRating[contender];
    }
}
