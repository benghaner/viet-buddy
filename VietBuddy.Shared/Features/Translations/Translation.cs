using System;
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
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        
        public Translation()
        {
            Examples = new List<string>();
            Tags = new List<string>();
            Created = DateTime.Now;
            Updated = DateTime.Now;
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
}
