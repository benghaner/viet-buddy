using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VietBuddy.Shared.Features.Translations
{
    public interface ITranslationRepository
    {
        Task AddAsync(Translation translation);
        Task DeleteAsync(Translation translation);
        Task<bool> ExistsAsync(Expression<Func<Translation, bool>> filter);
        Task<List<Translation>> FindAllAsync(Expression<Func<Translation, bool>> filter, Expression<Func<Translation, object>> sortKey, bool ascending = true, int limit = 100);
        Task<Translation> FindAsync(Expression<Func<Translation, bool>> filter);
        Task<List<string>> GetTagsAsync();
        Task UpdateAsync(Translation translation);
    }
}
