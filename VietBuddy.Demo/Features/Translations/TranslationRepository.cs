using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VietBuddy.Shared.Features.Translations;

namespace VietBuddy.Demo.Features.Translations
{
    public class TranslationRepository : ITranslationRepository
    {
        private readonly List<Translation> _translations;

        public TranslationRepository()
        {
            _translations = new List<Translation>();
        }

        public async Task AddAsync(Translation translation)
        {
            await Task.Run(() => _translations.Add(translation));
        }

        public async Task DeleteAsync(Translation translation)
        {
            await Task.Run(() => _translations.RemoveAll(t => t.Id == translation.Id));
        }

        public async Task<bool> ExistsAsync(Expression<Func<Translation, bool>> filter)
        {
            return await Task.Run(() => _translations.AsQueryable()
                .Where(filter)
                .Any());
        }

        public async Task<List<Translation>> FindAllAsync(Expression<Func<Translation, bool>> filter, Expression<Func<Translation, object>> sortKey, bool ascending = true, int limit = 100)
        {
            return await Task.Run(() => _translations);
        }

        public async Task<Translation> FindAsync(Expression<Func<Translation, bool>> filter)
        {
            return await Task.Run(() => _translations.AsQueryable()
                .Where(filter)
                .FirstOrDefault());
        }

        public async Task<List<string>> GetTagsAsync()
        {
            return await Task.Run(() => _translations.AsQueryable()
                .Where(t => t.Tags.Any())
                .SelectMany(t => t.Tags)
                .Distinct()
                .OrderBy(t => t)
                .ToList());
        }

        public async Task UpdateAsync(Translation translation)
        {
            var original = await FindAsync(t => t.Id == translation.Id);
            translation.Created = original.Created;
            translation.Updated = DateTime.Now;
            
            await Task.Run(() => original = translation);
        }
    }
}
