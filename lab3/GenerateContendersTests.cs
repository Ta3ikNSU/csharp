using lab2.model;
using lab2.model.Interfaces;

namespace lab3;

public class GenerateContendersTests
{
    [Test]
    public void Should_GenerateUniqueContendersName()
    {
        var contenderGenerator = new ContenderGenerator();
        var contenders = contenderGenerator.GetContenders();
        ISet<IContender> contendersSet = new HashSet<IContender>(contenders);
        Assert.That(contenders, Has.Count.EqualTo(contendersSet.Count));
    }
}