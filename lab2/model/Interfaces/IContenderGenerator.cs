namespace lab2.model.Interfaces;

public interface IContenderGenerator
{
    public IContender GenerateContender();
    public IList<IContender> GetContenders();
}