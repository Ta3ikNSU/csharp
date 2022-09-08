namespace lab2.Interfaces;

public interface IContender : IComparable
{
    string Name
    {
        get;
        set;
    }

    string Patronymic
    {
        get; 
        set;
    }

    int IComparable.CompareTo(object? obj)
    {
        if (obj == null)
        {
            throw new NullReferenceException();
        }
        var other = (obj as IContender)!;
        return Convert.ToInt32(this.Name.Equals(other.Name) && this.Patronymic.Equals(other.Patronymic));
    }
}