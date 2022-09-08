using System.Net;

namespace lab1;

public class Contender : IComparable
{
    private readonly string _name;
    private readonly string _patronymic;

    public Contender(string name, string patronymic)
    {
        this._name = name;
        this._patronymic = patronymic;
    }

    public string GetFullName()
    {
        return _name + " " + _patronymic;
    }

    public string GetName()
    {
        return _name;
    }
    
    public string GetPatronymic()
    {
        return _name;
    }
    

    public int CompareTo(object? obj)
    {
        if (obj == null)
        {
            throw new NullReferenceException();
        }
        var other = (obj as Contender)!;
        return Convert.ToInt32(this.GetFullName().Equals(other.GetFullName()));
    }
}