using lab5.Services;
using lab5.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab5;

internal static class Program
{
    public static void Main(string[] args)

    {
        var builder = WebApplication.CreateBuilder(args);
        initServices(builder.Services);
        initWebApplication(builder.Build());
    }

    private static void initServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllersWithViews();
        serviceCollection.AddSwaggerGen();
        serviceCollection.AddDbContext<AttemptContext>(
            opt => opt.UseNpgsql("Host=localhost:5432;Database=csharpdb;Username=postgres;Password=1234")
        );
        
        serviceCollection.AddSingleton<FriendService, FriendServiceImpl>();
        serviceCollection.AddSingleton<HallService, HallServiceImpl>();
        serviceCollection.AddSingleton<AttemptsGenerator, AttemptsGeneratorImpl>();
        serviceCollection.AddSingleton<ContenderGenerator, ContenderGeneratorImpl>();
        
        serviceCollection.AddHostedService<PrincessServiceImpl>();
    }
    
    private static void initWebApplication(WebApplication app)
    {
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.Run();
    }
}