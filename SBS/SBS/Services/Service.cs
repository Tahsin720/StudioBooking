using LanguageExt.Common;
using SBS.DataAccess.Interfaces;
using SBS.Services.Interfaces;
using System.Linq.Expressions;

namespace SBS.Services
{
    public class Service<TEntity, TId> : IService<TEntity, TId> where TEntity : class
    {
        private readonly IRepository<TEntity, TId> _repository;

        public Service(IRepository<TEntity, TId> repository)
        {
            _repository = repository;
        }

        public async Task<Result<bool>> AddAsync(TEntity entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<Result<bool>> AddRangeAsync(ICollection<TEntity> entities)
        {
            return await _repository.AddRangeAsync(entities);
        }

        public Result<bool> UpdateRangeAsync(ICollection<TEntity> entities)
        {
            return _repository.UpdateRangeAsync(entities);
        }

        public async Task<Result<bool>> DeleteAsync(TId id)
        {
            Result<TEntity> entityResult = await _repository.GetByIdAsync(id);

            return entityResult.Match(
                entity => _repository.DeleteAsync(entity),
                error => new Result<bool>(error)
            );
        }

        public async Task<Result<TEntity?>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.GetAsync(predicate);
        }

        public virtual async Task<Result<TEntity>> GetByIdAsync(TId id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Result<ICollection<TEntity>>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task<Result<ICollection<TEntity>>> ListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.ListAsync(predicate);
        }

        public Result<bool> UpdateAsync(TEntity entity)
        {
            return _repository.UpdateAsync(entity);
        }
    }
}
