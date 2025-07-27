using LanguageExt.Common;
using System.Linq.Expressions;

namespace SBS.Services.Interfaces
{
    public interface IService<TEntity, TId> where TEntity : class
    {
        Task<Result<TEntity>> GetByIdAsync(TId id);
        Task<Result<bool>> AddAsync(TEntity entity);
        Result<bool> UpdateAsync(TEntity entity);
        Task<Result<bool>> DeleteAsync(TId id);
        Task<Result<TEntity?>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<Result<ICollection<TEntity>>> ListAsync();
        Task<Result<ICollection<TEntity>>> ListAsync(Expression<Func<TEntity, bool>> predicate);
        Task<Result<bool>> AddRangeAsync(ICollection<TEntity> entities);
        Result<bool> UpdateRangeAsync(ICollection<TEntity> entities);
    }
}
