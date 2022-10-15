using lab2.model;
using lab2.model.Interfaces;

namespace lab3;

public class PrincessTests
{
    [Test]
    public void WhatTestHere()
    {
        IContenderGenerator contenderGenerator = new ContenderGenerator();
        IFriend friend = new Friend(contenderGenerator);
        IStrategy strategy = new SkipStrategy(friend, 1);
        IPrincess princess = new Princess(strategy);
        var contenders = contenderGenerator.GetContenders();
        IContender bestOption = null;
        foreach (var contender in contenders)
        {
            if (friend.GetRank(contender) < 55) continue;
            bestOption = contender;
            Assert.That(princess.SelectHusband(bestOption), Is.False);
            break;
        }
        IContender secondContender;
        foreach (var contender in contenders)
        {
            if (friend.GetRank(contender) >= 55) continue;
            secondContender = contender;
            Assert.That(princess.SelectHusband(secondContender), Is.False);
            break;
        }

        if (bestOption != null) Assert.That(princess.GetBestContender()!, Is.EqualTo(bestOption));
    }
}