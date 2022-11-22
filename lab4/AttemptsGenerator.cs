using lab2;
using lab2.model;
using lab2.model.Interfaces;
using lab4.DAO;

namespace lab4;

public static class AttemptsGenerator
{
    public static void GenerateEnvironment()
    {
        using AttemptContext context = new AttemptContext();
        context.Contenders.RemoveRange(context.Contenders);
        context.Attempts.RemoveRange(context.Attempts);
        IContenderGenerator contenderGenerator = new ContenderGenerator();
        for (var i = 1; i <= Constants.CountAttempts; i++)
        {
            Queue<int> queue = new Queue<int>(
                Enumerable.Range(1, Constants.CountOfContenders).OrderBy(_ => new Random().Next()));
            Queue<int> rating = new Queue<int>(
                Enumerable.Range(1, Constants.CountOfContenders).OrderBy(_ => new Random().Next()));
            for (var contenderNumber = 0; contenderNumber < Constants.CountOfContenders; contenderNumber++)
            {
                IContender contender = contenderGenerator.GenerateContender();
                ChoiceAttemptDao choiceAttempt = new ChoiceAttemptDao
                {
                    NumberAttempt = i,
                    Number = queue.Dequeue(),
                    ContenderDao = new ContenderDao(contender.Name, contender.Patronymic),
                    Rating = rating.Dequeue()
                };
                context.Attempts.Add(choiceAttempt);
            }
        }
        context.SaveChanges();
    }
}