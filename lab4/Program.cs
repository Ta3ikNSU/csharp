using lab2.model;
using lab2.model.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace lab4;

internal static class Program
{
    public static void Main(string[] args)
    {
        
        AttemptsGenerator.GenerateEnvironment();
        if (args.Length == 0)
        {
            
        }
        else
        {
            var attemptNumber = int.Parse(args[0]);

        }
        PreDestroy();
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



// internal static class Program
// {
//     public static void Main(string[] args)
//
//     {
//         using (AttemptContext context = new AttemptContext())
//         {
//             ChoiceAttemptDao choiceAttempt = new ChoiceAttemptDao {
//                 NumberAttempt = 1,
//                 Number = 2,
//                 Rating = 100,
//                 ContenderDao = new DAO.ContenderDao
//                 {
//                     Name = "Name",
//                     Patronymic = "Patronymic",
//                 }
//             };
//             context.Attempts.Add(choiceAttempt);
//             a
//         }
//
//         using (AttemptContext context = new AttemptContext())
//         {
//             var attempts = context.Attempts.ToList();
//             Console.WriteLine("attempts list:");
//             foreach (var attempt in attempts)
//             {
//                 Console.WriteLine($"{attempt.Id} : {attempt.NumberAttempt} : {attempt.ContenderDao}");
//             }
//         }
//     }
// }