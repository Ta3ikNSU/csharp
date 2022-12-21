using lab5.Model;
using lab5.Services.Interfaces;

namespace lab5.Services;

public class ContenderGeneratorImpl : ContenderGenerator
{
    public Contender GenerateContender()
    {
        return new Contender(Constants.GetRandomName() + " " + Constants.GetRandomName() + "ович");
    }
}