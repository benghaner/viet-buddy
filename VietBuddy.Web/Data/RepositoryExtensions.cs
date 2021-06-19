using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using VietBuddy.Shared.Features.Translations;

namespace VietBuddy.Web.Data
{
    public static class RepositoryExtensions
    {
        public static void AddMongoDb(this IServiceCollection services)
        {
            services.AddSingleton<IMongoClient, MongoClient>(s =>
            {
                var uri = s
                    .GetRequiredService<IConfiguration>()
                    .GetConnectionString("MongoUri");
                return new MongoClient(uri);
            });
            services.AddSingleton<TranslationRepository>();
        }
    }
}
