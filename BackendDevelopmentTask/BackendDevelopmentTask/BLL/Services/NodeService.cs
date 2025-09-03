using BackendDevelopmentTask.BLL.Models;
using BackendDevelopmentTask.DAL.Entities;
using BackendDevelopmentTask.DAL.Repositories;
using Mapster;

namespace BackendDevelopmentTask.BLL.Services;

public interface INodeService : IGenericService<NodeModel>;

public class NodeService(INodeRepository repository, ITreeRepository treeRepository) : GenericService<NodeModel, NodeEntity>(repository), INodeService
{
    public override async Task<NodeModel> CreateAsync(NodeModel nodeModel, CancellationToken cancellationToken)
    {
        var treeEntity = await treeRepository.GetByNameAsync(nodeModel.TreeName, cancellationToken) ?? throw new Exception("Tree with this name doesn't exist");
        
        if(nodeModel.ParentNodeId is not null)
        {
            var parentEntity = await _repository.GetByIdAsync(nodeModel.ParentNodeId.Value, cancellationToken: cancellationToken) ?? throw new Exception("Parent node with this id doesn't exist");
            if(parentEntity.TreeId != treeEntity.Id)
                throw new Exception("Parent node belongs to another tree");
        }

        nodeModel.TreeId = treeEntity.Id;
        var entityToCreate = nodeModel.Adapt<NodeEntity>();        
        var createdNodeEntity = await _repository.CreateAsync(entityToCreate, cancellationToken);        
        
        var createdNodeModel = createdNodeEntity.Adapt<NodeModel>();  
        return createdNodeModel;
    }
}