using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using VietBuddy.Shared.Features.Translations;

namespace VietBuddy.Sandbox
{
    public class MongoService
    {
        private readonly IMongoClient _client;
        private readonly TranslationRepository _translations;

        public MongoService(IMongoClient client, TranslationRepository translations)
        {
            _client = client;
            _translations = translations;
        }
        
        public async Task RunAsync()
        {
            await _translations.GetAsync();
        }
    }
}
