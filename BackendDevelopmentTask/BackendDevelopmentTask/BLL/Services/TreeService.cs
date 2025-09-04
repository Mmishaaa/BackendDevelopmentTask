using BackendDevelopmentTask.BLL.Models;
using BackendDevelopmentTask.DAL.Entities;
using BackendDevelopmentTask.DAL.Repositories;

namespace BackendDevelopmentTask.BLL.Services;

public interface ITreeService : IGenericService<TreeModel>
{
    Task<TreeEntity> GetByNameAsync(string treeName, CancellationToken cancellationToken);
}

public class TreeService(ITreeRepository repository) : GenericService<TreeModel, TreeEntity>(repository), ITreeService
{
    public async Task<TreeEntity> GetByNameAsync(string treeName, CancellationToken cancellationToken)
    {
        var treeEntity = await repository.GetByNameAsync(treeName, cancellationToken);

        if (treeEntity is null)
        {
            var createdTree = await repository.CreateAsync(new TreeEntity { Name = treeName }, cancellationToken);
            return createdTree;
        }
        
        return treeEntity;
    }
}