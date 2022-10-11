namespace lab2.Interfaces;

public interface IContenderGenerator
{
    public IContender GenerateContender();
    public IList<IContender> GetContenders();
}