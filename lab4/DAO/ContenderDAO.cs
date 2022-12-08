
using lab2.model;

namespace lab4.DAO;

public class ContenderDao
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Patronymic { get; set; }

    public Contender toContender()
    {
        return new Contender(Name, Patronymic);
    }
}