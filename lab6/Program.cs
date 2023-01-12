using lab6.Model;
using lab6.Services;
using lab6.Services.Interfaces;
using lab6.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace lab6;

internal static class Program
{
    public static void Main(string[] args)

    {
        var builder = WebApplication.CreateBuilder(args);
        InitServices(builder.Services);
        InitWebApplication(builder.Build());
    }

    private static void InitServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllersWithViews();
        serviceCollection.AddSwaggerGen();
        
        serviceCollection.AddDbContext<AttemptContext>(
            opt => opt.UseNpgsql("Host=localhost:5432;Database=csharpdb;Username=postgres;Password=1234")
        );
        
        serviceCollection.AddScoped<Consumer>();
        serviceCollection.AddSingleton<FriendService, FriendServiceImpl>();
        serviceCollection.AddSingleton<HallService, HallServiceImplWithProducer>();
        serviceCollection.AddSingleton<AttemptsGenerator, AttemptsGeneratorImpl>();
        serviceCollection.AddSingleton<ContenderGenerator, ContenderGeneratorImpl>();
        serviceCollection.AddSingleton<ContendersService, ContendersServiceImpl>();

        serviceCollection.AddMassTransit(x =>
        {
            x.UsingInMemory((context,cfg) =>
            {
                // cfg.ConfigureEndpoints(context);
            });
            x.AddConsumer<Consumer>();
        });

        
        serviceCollection.AddHostedService<PrincessServiceImpl>();
    }

    private static void InitWebApplication(WebApplication app)
    {
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.Run();
    }
}