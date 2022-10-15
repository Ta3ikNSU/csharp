namespace lab2.model.Interfaces;

public interface IPrincess
{
    protected IContender? BestContender { get; set; }

    public bool SelectHusband(IContender contender);

    public IContender? GetBestContender()
    {
        return BestContender;
    }
}
