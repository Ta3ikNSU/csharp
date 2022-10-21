using System.Text;

namespace lab1;

internal class Program
{
    private static readonly int CountOfContenders = 10;

    public static void Main()
    {
        var contenders = InitContenders();
        var friend = new Friend(contenders);
        var hall = new Hall(contenders);
        var princess = new Princess(friend);

        var result = 10;
        foreach (var contender in hall.Contenders)
            if (princess.SelectHusband(contender))
            {
                var bestContender = princess.GetBestContender();
                if (contenders != null)
                {
                    result = friend.GetRank(bestContender!) > 50 ? friend.GetRank(bestContender!) : 0;
                    break;
                }
            }

        WriteOut(contenders, result);
    }

    private static List<Contender> InitContenders()
    {
        var contenders = new List<Contender>();
        for (var i = 0; i < CountOfContenders; i++) contenders.Add(GenerateContender());

        return contenders;
    }

    private static Contender GenerateContender()
    {
        var name = Constants.NamesQueue.Dequeue();
        var patronymic = Constants.NamesQueue.Dequeue() + "ович";
        return new Contender(name, patronymic);
    }

    private static void WriteOut(List<Contender>? contenders, int result)
    {
        var fileName = DateTime.Now.ToLongTimeString().Replace(":", "_") + ".txt";
        using var fs = File.Create(fileName);
        foreach (var contenderName in contenders!.Select(contender =>
                     new UTF8Encoding(true).GetBytes(contender.GetFullName() + '\n')))
            fs.Write(contenderName, 0, contenderName.Length);

        var resultString = new UTF8Encoding(true).GetBytes(result.ToString() + '\n');
        fs.Write(resultString, 0, resultString.Length);
    }
}