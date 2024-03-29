﻿using lab2.Exception;
using lab2.model;
using lab2.model.Interfaces;

namespace lab3;

public class HallTests
{
    [Test]
    public void Should_GetNextContender_When_HallNotEmpty_And_Exception_When_HallEmpty()
    {
        IContenderGenerator contenderGenerator = new ContenderGenerator();
        IHall hall = new Hall(contenderGenerator);
        ISet<IContender> contenders = new HashSet<IContender>();
        while (!hall.IsHallEmpty())
        {
            var contender = hall.GetNextContender();
            Assert.That(!contenders.Contains(contender), Is.True);
            contenders.Add(contender);
        }

        Assert.Throws<HallEmptyException>(delegate { hall.GetNextContender(); });
    }
}