using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using VietBuddy.Web.Shared;

namespace VietBuddy.Web.Features.Translations
{
    public class Translation : IJsonClonable
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

    public static class TranslationExtenions
    {
        public static List<Translation> ReplaceById(this List<Translation> translations, Translation translation)
        {
            translations.RemoveAll(t => t.Id == translation.Id);
            translations.Add(translation);
            return translations;
        }
    }
}