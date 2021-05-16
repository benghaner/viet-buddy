using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace VietBuddy.Web.Features.Translations
{
    public class TranslationRepository
    {
        private readonly IMongoCollection<Translation> _collection;

        public TranslationRepository(IMongoClient mongoClient)
        {
            _collection = mongoClient
                .GetDatabase("viet_buddy")
                .GetCollection<Translation>("translations");
        }

        public async Task AddAsync(Translation translation)
        {
            try
            {
                await _collection.InsertOneAsync(translation);
            }
            catch (MongoException e)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<List<Translation>> GetAsync()
        {
            try
            {
                return await _collection.Find(c => true).ToListAsync();
            }
            catch (MongoException e)
            {
                throw new NotImplementedException();
            }
        }
    }
}