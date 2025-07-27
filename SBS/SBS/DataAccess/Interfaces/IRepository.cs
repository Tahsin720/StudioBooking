using LanguageExt.Common;
using System.Linq.Expressions;

namespace SBS.DataAccess.Interfaces
{
    public interface IRepository<TEntity, TId> where TEntity : class
    {
        Task<Result<TEntity>> GetByIdAsync(TId id);
        Task<Result<ICollection<TEntity>>> ListAsync();
        Task<Result<bool>> AddAsync(TEntity entity);
        Task<Result<bool>> AddRangeAsync(ICollection<TEntity> entities);
        Result<bool> UpdateAsync(TEntity entity);
        Result<bool> UpdateRangeAsync(ICollection<TEntity> entities);
        Result<bool> DeleteAsync(TEntity entity);
        Task<Result<ICollection<TEntity>>> ListAsync(Expression<Func<TEntity, bool>> predicate);
        Task<Result<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
