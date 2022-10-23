using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace lab4;

// internal static class Program
// {
//     public static void Main(string[] args)
//     {
//         if (args.Length == 0) throw new ArgumentException("Please enter a attempt number");
//         var attemptNumber = int.Parse(args[0]);
//         IContenderGenerator contenderGenerator = new ContenderGenerator();
//         contenderGenerator.GetContenders();
//         var contendersRating = new Dictionary<IContender, int>();
//         var contenders = contenderGenerator.GetContenders();
//         for (var i = 0; i < contenders.Count; i++) contendersRating.Add(contenders[i], i + 1);
//         ChoiceAttempt attempt = new ChoiceAttempt
//         {
//             NumberAttempt = 1,
//             ContendersRating = contendersRating,
//             Contenders = new Queue<IContender>(contenderGenerator.GetContenders())
//         };
//     }
// }

internal static class Program
{
    public static void Main(string[] args)

    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) => { services.AddDbContext<AttemptContext>(); });
    }
}