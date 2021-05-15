using System;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace VietBuddy.Web.Features.Translations
{
    public class TranslationRepository
    {
        private readonly IMongoCollection<Translation> _translations;

        public TranslationRepository(IMongoClient mongoClient)
        {
            _translations = mongoClient
                .GetDatabase("viet_buddy")
                .GetCollection<Translation>("translations");
        }

        public async Task AddAsync(Translation translation)
        {
            try
            {
                await _translations.InsertOneAsync(translation);
            }
            catch (MongoException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}