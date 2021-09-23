using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using VietBuddy.Shared.Features.Translations;

namespace VietBuddy.Web.Features.Translations
{
    public class TranslationRepository : ITranslationRepository
    {
        private readonly IMongoCollection<Translation> _collection;
        private const int DefaultLimit = 100;

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
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Translation> FindAsync(Expression<Func<Translation, bool>> filter)
        {
            try
            {
                return await _collection
                    .Find(filter)
                    .FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<List<Translation>> FindAllAsync(
            Expression<Func<Translation, bool>> filter,
            Expression<Func<Translation, object>> sortKey,
            bool ascending = true,
            int limit = DefaultLimit)
        {
            SortDefinition<Translation> sort;

            if (ascending == true)
                sort = Builders<Translation>.Sort.Ascending(sortKey);
            else
                sort = Builders<Translation>.Sort.Descending(sortKey);

            try
            {
                return await _collection
                    .Find(filter)
                    .Sort(sort)
                    .Limit(limit)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<bool> ExistsAsync(Expression<Func<Translation, bool>> filter)
        {
            try
            {
                return await _collection
                    .Find(filter)
                    .CountDocumentsAsync() > 0;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task UpdateAsync(Translation translation)
        {
            try
            {
                var original = await FindAsync(t => t.Id == translation.Id);
                translation.Created = original.Created;
                translation.Updated = DateTime.Now;

                await _collection.ReplaceOneAsync<Translation>(t => t.Id == translation.Id, translation);
            }
            catch (Exception)
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
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<List<string>> GetTagsAsync()
        {
            try
            {
                return await _collection
                    .AsQueryable()
                    .Where(t => t.Tags.Any())
                    .SelectMany(t => t.Tags)
                    .Distinct()
                    .OrderBy(t => t)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
