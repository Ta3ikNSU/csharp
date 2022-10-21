using lab2.Exception;
using lab2.model;
using lab2.model.Interfaces;

namespace lab3;

public class FriendTests
{
    [Test]
    public void Should_CorrectCompare_When_ContendersValid()
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

    [Test]
    public void Should_CorrectCompare_When_ContendersInvalid()
    {
        IContenderGenerator contenderGenerator = new ContenderGenerator();
        var friend = new Friend(contenderGenerator);
        var firstContender = contenderGenerator.GenerateContender();
        var lastContender = contenderGenerator.GenerateContender();
        Assert.Multiple(() =>
        {
            Assert.Throws<UnknownContenderException>(() => friend.CompareContenders(firstContender, lastContender));
            Assert.Throws<UnknownContenderException>(() => friend.GetRank(lastContender));
        });
    }
}