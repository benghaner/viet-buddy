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
        public IList<Example> Examples { get; set; }
        public IList<Tag> Tags { get; set; }
        
        public Translation()
        {
            Tags = new List<Tag>();
            Examples = new List<Example>();
        }
    }

    public class Example { public string Text { get; set; } }
    
    public class Tag : IEquatable<Tag>
    {
        public string Text { get; set; }

        public bool Equals(Tag other)
        {
            if (other is null)
                return false;
            return this.Text == other.Text;
        }

        public override bool Equals(object obj) => Equals(obj as Tag);
        public override int GetHashCode() => this.Text.GetHashCode();
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
