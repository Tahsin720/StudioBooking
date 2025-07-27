using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;
using SBS.DataAccess.Interfaces;
using SBS.Domain.Database;
using SBS.Utilities.Exceptions;
using System.Linq.Expressions;

namespace SBS.DataAccess
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class
    {
        private readonly AppDbContext _dbContext;
        private DbSet<TEntity> _dbSet => _dbContext.Set<TEntity>();
        private readonly Type entityType = typeof(TEntity);

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<bool>> AddAsync(TEntity entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                _ = await _dbContext.SaveChangesAsync() > 0;
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(new Exception($"Error adding entity: {ex.Message}"));
            }
        }

        public async Task<Result<bool>> AddRangeAsync(ICollection<TEntity> entities)
        {
            try
            {
                await _dbSet.AddRangeAsync(entities);
                _ = await _dbContext.SaveChangesAsync() > 0;
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(new Exception($"Error adding entity: {ex.Message}"));
            }
        }

        public Result<bool> DeleteAsync(TEntity entity)
        {
            try
            {
                _dbSet.Remove(entity);
                _ = _dbContext.SaveChanges() > 0;
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(new Exception($"Error removing entity: {ex.Message}"));
            }
        }

        public async Task<Result<TEntity>> GetByIdAsync(TId id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity is null)
                    return new Result<TEntity>(new NotFoundException("Requested resource not found!"));
                return new Result<TEntity>(entity);
            }
            catch (Exception ex)
            {
                return new Result<TEntity>(new Exception($"Error getting entity: {ex.Message}"));
            }
        }

        public async Task<Result<ICollection<TEntity>>> ListAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                return new Result<ICollection<TEntity>>(new Exception($"Error getting list: {ex.Message}"));
            }
        }

        public Result<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                _dbSet.Update(entity);
                _ = _dbContext.SaveChanges() > 0;
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(new Exception($"Error updating entity: {ex.Message}"));
            }
        }

        public async Task<Result<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var entity = await _dbSet.FirstOrDefaultAsync(predicate);

                if (entity is null)
                    return new Result<TEntity>(new NotFoundException("Entity not found"));

                return new Result<TEntity>(entity);
            }
            catch (Exception ex)
            {
                return new Result<TEntity>(new Exception($"Error getting entity: {ex.Message}"));
            }
        }

        public async Task<Result<ICollection<TEntity>>> ListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await _dbSet.Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                return new Result<ICollection<TEntity>>(new Exception($"Error getting list: {ex.Message}"));
            }
        }

        public Result<bool> UpdateRangeAsync(ICollection<TEntity> entities)
        {
            try
            {
                _dbSet.UpdateRange(entities);
                _ = _dbContext.SaveChanges() > 0;
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(new Exception($"Error updating entity: {ex.Message}"));
            }
        }
    }
}
