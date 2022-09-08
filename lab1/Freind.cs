namespace lab1;

public class Friend
{
    private readonly Dictionary<Contender, int> _contendersRating;

    public bool CompareContenders(Contender contenderNameFirst, Contender contenderNameSecond)
    {
        return _contendersRating[contenderNameFirst] > _contendersRating[contenderNameSecond];
    }

    public Friend(List<Contender> contenders)
    {
        _contendersRating = new Dictionary<Contender, int>();
        for (var i = 0; i < contenders.Count; i++)
        {
            _contendersRating.Add(contenders[i], i+1);
        }
    }

    public int GetRank(Contender contender)
    {
        return _contendersRating[contender];
    }
    
}