using BackendDevelopmentTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendDevelopmentTask.DAL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity?> GetByIdAsync(Guid id, bool trackChanges = false, CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetAllAsync(bool trackChanges = false, CancellationToken cancellationToken = default);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
        Task DeleteByIdAsync(TEntity entity, CancellationToken cancellationToken);
    }
    
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected ApplicationDbContext _context;
        protected DbSet<TEntity> _dbSet; 

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var createdEntity = await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return createdEntity.Entity;
        }

        public virtual Task<List<TEntity>> GetAllAsync(bool trackChanges, CancellationToken cancellationToken)
        {
            var query = trackChanges ? _dbSet : _dbSet.AsNoTracking();
            return query.ToListAsync(cancellationToken);
        }

        public virtual Task<TEntity?> GetByIdAsync(Guid id, bool trackChanges, CancellationToken cancellationToken)
        {
            var query = trackChanges ? _dbSet : _dbSet.AsNoTracking();
            return query.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var updatedEntity = _dbSet.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return updatedEntity.Entity;
        }
        
        public virtual async Task DeleteByIdAsync(TEntity entity, CancellationToken cancellationToken)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}