using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VietBuddy.Shared.Features.Translations;

namespace VietBuddy.Demo.Features.Translations
{
    #pragma warning disable CS1998
    public class TranslationRepository : ITranslationRepository
    {
        private readonly List<Translation> _translations;

        public TranslationRepository()
        {
            _translations = new List<Translation>();
        }

        public async Task AddAsync(Translation translation)
        {
            translation.Id = Guid.NewGuid().ToString();
            _translations.Add(translation);
        }

        public async Task DeleteAsync(Translation translation)
        {
            _translations.RemoveAll(t => t.Id == translation.Id);
        }

        public async Task<bool> ExistsAsync(Expression<Func<Translation, bool>> filter)
        {
            return _translations.AsQueryable()
                .Where(filter)
                .Any();
        }

        public async Task<List<Translation>> FindAllAsync(Expression<Func<Translation, bool>> filter, Expression<Func<Translation, object>> sortKey, bool ascending = true, int limit = 100)
        {
            if (ascending == true)
            {
                return _translations.AsQueryable()
                    .Where(filter)
                    .OrderBy(sortKey)
                    .ToList();
            }

            return _translations.AsQueryable()
                .Where(filter)
                .OrderByDescending(sortKey)
                .ToList();
        }

        public async Task<Translation> FindAsync(Expression<Func<Translation, bool>> filter)
        {
            return _translations.AsQueryable()
                .Where(filter)
                .FirstOrDefault();
        }

        public async Task<List<string>> GetTagsAsync()
        {
            return _translations.AsQueryable()
                .Where(t => t.Tags.Any())
                .SelectMany(t => t.Tags)
                .Distinct()
                .OrderBy(t => t)
                .ToList();
        }

        public async Task UpdateAsync(Translation translation)
        {
            translation.Updated = DateTime.Now;
            _translations.RemoveAll(t => t.Id == translation.Id);
            await AddAsync(translation);
        }
    }
}
