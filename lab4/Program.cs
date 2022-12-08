using System.Diagnostics.CodeAnalysis;
using lab2.model;
using lab2.model.Interfaces;
using lab4.Exception;
using Microsoft.EntityFrameworkCore;

namespace lab4;

internal static class Program
{
    [SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records", MessageId = "count: 100")]
    public static async Task Main(string[] args)
    {
        try
        {
            await AttemptsGenerator.GenerateEnvironment();
            if (args.Length == 0)
            {
                Console.WriteLine("Enter the attempt number when starting the application [1..100]");
            }
            else
            {
                var attemptNumber = int.Parse(args[0]);
                double sum = 0;
                int attemptRating = 0;
                for (int i = 1; i <= 100; i++)
                {
                    int result = getDataAndEmulateBehavior(i);
                    sum += result;
                    if (i == attemptNumber)
                    {
                        attemptRating = result;
                    }
                }

                Console.WriteLine("Average rating over 100 attempts : " + sum / 100);
                Console.WriteLine("Rating in the selected attempt : " + attemptRating);
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
        finally
        {
            PreDestroy();
        }

    }

    private static int getDataAndEmulateBehavior(int attemptNumber)
    {
        using var context = new AttemptContext();
        IQueryable<ChoiceAttemptDao>? attemptDaos = context.Attempts.Where(dao => dao.NumberAttempt == attemptNumber);

        var attempts = new List<ChoiceAttemptDao>(attemptDaos);
        IDictionary<IContender, int> contendersRating = new Dictionary<IContender, int>();
        IContender[] contenderQueueAsArray = new IContender[100];
        if (attempts.Count != 100)
        {
            throw new GenerateEnvironException("Attempt generated incorrectly. Actual size is : " + attempts.Count);
        }

        foreach (var attempt in attempts)
        {
            IContender contender = new Contender(attempt.Name, attempt.Patronymic);
            var contenderRating = attempt.Rating;
            var number = attempt.Number;

            contendersRating.Add(contender, contenderRating);
            contenderQueueAsArray[number - 1] = contender;
        }

        Queue<IContender> contendersQueue = new Queue<IContender>(contenderQueueAsArray);
        return emulateBehavior(contendersQueue, contendersRating);
    }

    private static int emulateBehavior(
        Queue<IContender> contendersQueue,
        IDictionary<IContender, int> contendersRating
    )
    {
        IFriend _friend = new Friend(contendersRating);
        IStrategy skipStrategy = new SkipStrategy(_friend, 1);
        IPrincess _princess = new Princess(skipStrategy);
        IHall _hall = new Hall(contendersQueue);
        var result = 10;
        foreach (IContender contender in _hall)
        {
            if (!_princess.SelectHusband(contender))
            {
                continue;
            }

            var bestContender = _princess.GetBestContender();
            if (bestContender == null)
            {
                continue;
            }

            result = _friend.GetRank(bestContender!) > 50 ? _friend.GetRank(bestContender!) : 0;
            break;
        }

        return result;
    }

    private static void PreDestroy()
    {
        using AttemptContext context = new AttemptContext();
        var tableNames = context.Model.GetEntityTypes()
            .Select(t => t.GetTableName())
            .Distinct()
            .ToList();

        foreach (var tableName in tableNames)
        {
            context.Database.ExecuteSqlRaw($"TRUNCATE TABLE \"{tableName}\" cascade;");
        }
    }
}