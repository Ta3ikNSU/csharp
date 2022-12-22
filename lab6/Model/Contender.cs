using Lombok.NET;

namespace lab6.Model;

[ToString]
public partial class Contender
{
    public Contender(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}