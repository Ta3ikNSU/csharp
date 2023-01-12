using lab6.Model;
using lab6.Services.Interfaces;

namespace lab6.Services;

public class ContenderGeneratorImpl : ContenderGenerator
{
    public Contender GenerateContender()
    {
        return new Contender(Constants.GetRandomName() + " " + Constants.GetRandomName() + "ович");
    }
}