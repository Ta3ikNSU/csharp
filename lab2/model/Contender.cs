using lab2.model.Interfaces;

namespace lab2.model;

public class Contender : IContender
{
    private string _name;
    private string _patronymic;

    public Contender(string name, string patronymic)
    {
        _name = name;
        _patronymic = patronymic;
    }

    string IContender.Name
    {
        get => _name;
        set => _name = value;
    }

    string IContender.Patronymic
    {
        get => _patronymic;
        set => _patronymic = value;
    }
}