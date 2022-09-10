namespace lab1;

using System.Text;

class Program
{

    private static int CountOfContenders = 100;
    
    public static void Main()
    {
        List<Contender> contenders = InitContenders();
        Friend friend = new Friend(contenders);
        Hall hall = new Hall(contenders);
        Princess princess = new Princess(friend);

        int result = 10;
        foreach (var contender in hall.Contenders)
        {
            if (princess.SelectHusband(contender))
            {
                Contender? bestContender = princess.GetBestContender();
                if (contenders != null)
                {
                    result = friend.GetRank(bestContender!) > 50 ? friend.GetRank(bestContender!) : 0;
                    break;
                }
            }
        }
        
        WriteOut(contenders, result);
    }

    private static List<Contender> InitContenders()
    {
        List<Contender> contenders = new List<Contender>();
        for (int i = 0; i < CountOfContenders; i++)
        {
            contenders.Add(GenerateContender());
        }

        return contenders;
    }
    
    private static Contender GenerateContender()
    {
        string name = Constants.NamesQueue.Dequeue();
        string patronymic = Constants.NamesQueue.Dequeue() + "ович"; 
        return new Contender(name, patronymic);
    }

    private static void WriteOut(List<Contender>? contenders, int result)
    {
        var fileName = DateTime.Now.ToLongTimeString() + ".txt";
        using var fs = File.Create(fileName);
        foreach (var contenderName in contenders!.Select(contender =>
                     new UTF8Encoding(true).GetBytes(contender.GetFullName() + '\n')))
        {
            fs.Write(contenderName, 0, contenderName.Length);
        }

        Byte[] resultString = new UTF8Encoding(true).GetBytes(result.ToString() + '\n');
        fs.Write(resultString, 0, resultString.Length);
    }
}