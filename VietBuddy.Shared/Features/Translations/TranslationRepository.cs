using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace VietBuddy.Shared.Features.Translations
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
            catch (MongoException)
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
            catch (MongoException)
            {
                throw new NotImplementedException();
            }
        }

        public async Task UpdateAsync(Translation translation)
        {
            try
            {
                await _collection.ReplaceOneAsync<Translation>(t => t.Id == translation.Id, translation);
            }
            catch (MongoException)
            {
                throw new NotImplementedException();
            }
        }

        public async Task DeleteAsync(Translation translation)
        {
            try
            {
                await _collection.DeleteOneAsync<Translation>(t => t.Id == translation.Id);
            }
            catch (MongoException)
            {
                throw new NotImplementedException();
            }
        }
    }
}