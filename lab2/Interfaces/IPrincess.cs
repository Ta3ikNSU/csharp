namespace lab2.Interfaces;

public interface IPrincess
{
    protected IHall Hall
    {
        get;
        set;
    }

    protected IContender? BestContender
    {
        get;
        set;
    }

    public bool SelectHusband(IContender contender);
    
    public IContender? GetBestContender()
    {
        return BestContender;
    }
}