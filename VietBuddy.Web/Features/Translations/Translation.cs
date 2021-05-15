using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VietBuddy.Web.Features.Translations
{
    public class Translation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Vietnamese { get; set; }
        public string English { get; set; }
        public List<string> Tags { get; set; }
        public List<string> Examples { get; set; }

        public Translation()
        {
            Tags = new List<string>();
            Examples = new List<string>();
        }
    }
}