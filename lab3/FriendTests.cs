using lab2.model;
using lab2.model.Interfaces;

namespace lab3;

public class FriendTests
{
    [Test]
    public void UniqueContendersName()
    {
        IContenderGenerator contenderGenerator = new ContenderGenerator();
        var friend = new Friend(contenderGenerator);
        var contenders = contenderGenerator.GetContenders();
        var firstContender = contenders[0];
        var lastContender = contenders[^1];
        var firstRating = friend.GetRank(firstContender);
        var lastRating = friend.GetRank(lastContender);
        Assert.That(friend.CompareContenders(firstContender, lastContender), Is.EqualTo(firstRating > lastRating));
    }
}