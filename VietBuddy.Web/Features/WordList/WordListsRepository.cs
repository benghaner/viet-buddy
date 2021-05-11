using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace VietBuddy.Web.Features.WordList
{
    public class WordListsRepository
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoCollection<WordList> _wordLists;

        public WordListsRepository(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;

            var camelCaseConvention = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);

            _wordLists = _mongoClient.GetDatabase("viet_buddy").GetCollection<WordList>("wordLists");
        }

        public async Task<List<WordList>> GetWordListsAsync()
        {
            var projection = Builders<WordList>.Projection
                .Include(w => w.Id)
                .Include(w => w.Title);

            try
            {
                return await _wordLists
                    .Find(new BsonDocument())
                    .Project<WordList>(projection)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<WordList> GetWordListAsync(string id)
        {
            try
            {
                return await _wordLists
                    .Find<WordList>(w => w.Id == id)
                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task AddWordListAsync(WordList wordList)
        {
            try
            {
                await _wordLists.InsertOneAsync(wordList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task DeleteWordListAsync(string id)
        {
            try
            {
                await _wordLists.DeleteOneAsync(Builders<WordList>.Filter.Where(w => w.Id == id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}