﻿using lab2.Interfaces;

namespace lab2;

internal static class Program
{
    public static void Main(string[] args)

    {
        CreateHostBuilder(args).Build().Run();
    }


    private static IHostBuilder CreateHostBuilder(string[] args)

    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddHostedService<PrincessService>();

                services.AddScoped<IHall, Hall>();

                services.AddScoped<IPrincess, Princess>();

                services.AddScoped<IFriend, Friend>();

                services.AddScoped<IContenderGenerator, ContenderGenerator>();
            });
    }
}