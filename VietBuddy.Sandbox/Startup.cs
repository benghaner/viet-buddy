using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using VietBuddy.Shared.Features.Translations;

namespace VietBuddy.Sandbox
{
    public static class Startup
    {
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host
                .CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(builder => {
                    builder.AddUserSecrets<Program>();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<IMongoClient, MongoClient>(s => {
                        var uri = s
                            .GetRequiredService<IConfiguration>()
                            .GetConnectionString("MongoUri");
                        return new MongoClient(uri);
                    });
                    services.AddTransient<TranslationRepository>();
                    services.AddTransient<MongoService>();
                });
        }
    }
}
