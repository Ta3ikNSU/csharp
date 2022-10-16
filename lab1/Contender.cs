namespace lab1;

public class Contender : IComparable
{
    private readonly string _name;
    private readonly string _patronymic;

    public Contender(string name, string patronymic)
    {
        _name = name;
        _patronymic = patronymic;
    }

    public int CompareTo(object? obj)
    {
        if (obj == null) throw new ArgumentNullException();
        var other = (obj as Contender)!;
        return Convert.ToInt32(GetFullName().Equals(other.GetFullName()));
    }

    public string GetFullName()
    {
        return _name + " " + _patronymic;
    }
}
