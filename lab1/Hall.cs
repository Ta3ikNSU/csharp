namespace lab1;

public class Hall
{
    public Queue<Contender> Contenders;
    public Hall(List<Contender> contenders)
    {
        Contenders = new Queue<Contender>(contenders.OrderBy(_ => new Random().Next()));
    }

    public Contender GetNextContender()
    {
        return Contenders.Dequeue();
    }

    public bool IsHallEmpty()
    {
        return Contenders.Count == 0;
    }
}