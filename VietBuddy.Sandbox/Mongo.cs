using System;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace VietBuddy.Sandbox
{
    public class Mongo
    {
        private readonly IMongoClient _client;

        public Mongo(IMongoClient client)
        {
            _client = client;
        }
        
        public async Task RunAsync()
        {
            await Task.Delay(0);
        }
    }
}
