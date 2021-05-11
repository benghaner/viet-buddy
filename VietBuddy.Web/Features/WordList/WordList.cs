using System.Collections.Generic;
using FluentValidation;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VietBuddy.Web.Features.WordList
{
    public class WordList
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public List<Word> Words { get; set; }

        public WordList()
        {
            Words = new List<Word>();
        }
    }

    public class WordListValidator : AbstractValidator<WordList>
    {
        public WordListValidator()
        {
            RuleFor(w => w.Title).NotEmpty().WithMessage("Give us a title");
        }
    }
}
