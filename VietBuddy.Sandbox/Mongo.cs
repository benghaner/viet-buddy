using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using VietBuddy.Shared.Features.Translations;

namespace VietBuddy.Sandbox
{
    public class Mongo
    {
        private readonly IMongoClient _client;
        private readonly TranslationRepository _translations;

        public Mongo(IMongoClient client, TranslationRepository translations)
        {
            _client = client;
            _translations = translations;
        }
        
        public async Task RunAsync()
        {
            await Task.Delay(0);
        }
    }
}
