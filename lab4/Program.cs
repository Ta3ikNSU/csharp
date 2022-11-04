using lab2.model;
using lab2.model.Interfaces;

namespace lab4;

internal static class Program
{
    public static void Main(string[] args)
    {
        // if (args.Length == 0) throw new ArgumentException("Please enter a attempt number");
        // var attemptNumber = int.Parse(args[0]);
        IContenderGenerator contenderGenerator = new ContenderGenerator();
        contenderGenerator.GetContenders();
        var contendersRating = new Dictionary<IContender, int>();
        var contenders = contenderGenerator.GetContenders();
        for (var i = 0; i < contenders.Count; i++) contendersRating.Add(contenders[i], i + 1);
        var attempt = new ChoiceAttemptDao(
            1,
            contendersRating,
            new Queue<IContender>(contenderGenerator.GetContenders())
        );

        using (var db = new AttemptContext())
        {
            db.Attempts.Add(attempt);
            db.SaveChanges();
        }
    }
}