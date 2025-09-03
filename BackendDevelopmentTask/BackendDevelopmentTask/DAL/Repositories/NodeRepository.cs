using BackendDevelopmentTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendDevelopmentTask.DAL.Repositories;

public interface INodeRepository : IGenericRepository<NodeEntity>
{
    Task<bool> IsNameInTheTreeUniqueAsync(string treeName, string newNodeName, CancellationToken cancellationToken);
}

public class NodeRepository(ApplicationDbContext context) : GenericRepository<NodeEntity>(context), INodeRepository
{
    public override Task<NodeEntity?> GetByIdAsync(Guid id, bool trackChanges, CancellationToken cancellationToken)
    {
        var query = trackChanges ? _dbSet : _dbSet.AsNoTracking();
        var nodeEntity = query
            .Include(n => n.ChildNodes)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        return nodeEntity;
    }

    public async Task<bool> IsNameInTheTreeUniqueAsync(string treeName, string newNodeName, CancellationToken cancellationToken)
    {
        return !await _dbSet
            .Where(n => n.TreeName == treeName)
            .AnyAsync(n => n.Name == newNodeName, cancellationToken);
    }
}
