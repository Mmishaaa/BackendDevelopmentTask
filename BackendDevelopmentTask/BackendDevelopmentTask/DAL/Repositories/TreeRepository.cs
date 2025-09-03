using BackendDevelopmentTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendDevelopmentTask.DAL.Repositories;

public interface ITreeRepository : IGenericRepository<TreeEntity>
{
    public Task<TreeEntity?> GetByNameAsync(string name, CancellationToken cancellationToken);
}

public class TreeRepository(ApplicationDbContext context) : GenericRepository<TreeEntity>(context), ITreeRepository
{
    public async Task<TreeEntity?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await _context.Trees.FirstOrDefaultAsync(t => t.Name == name, cancellationToken);
    }
}