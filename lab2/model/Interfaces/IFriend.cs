namespace lab2.model.Interfaces;

public interface IFriend
{
    public bool CompareContenders(IContender contenderNameFirst, IContender contenderNameSecond);

    public int GetRank(IContender contender);
}