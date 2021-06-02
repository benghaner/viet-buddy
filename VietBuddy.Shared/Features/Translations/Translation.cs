using System.Collections.Generic;
using FluentValidation;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VietBuddy.Shared.Features.Translations
{
    public class Translation : IJsonClonable
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Vietnamese { get; set; }
        public string English { get; set; }
        public List<string> Examples { get; set; }
        public List<string> Tags { get; set; }
        
        public Translation()
        {
            Examples = new List<string>();
            Tags = new List<string>();
        }
    }

    public class TranslationValidator : AbstractValidator<Translation>
    {
        public TranslationValidator()
        {
            RuleFor(t => t.Vietnamese).NotEmpty();
            RuleFor(t => t.English).NotEmpty();
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
