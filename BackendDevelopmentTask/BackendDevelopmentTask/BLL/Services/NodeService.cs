using BackendDevelopmentTask.BLL.Exceptions;
using BackendDevelopmentTask.BLL.Models;
using BackendDevelopmentTask.DAL.Entities;
using BackendDevelopmentTask.DAL.Repositories;
using Mapster;

namespace BackendDevelopmentTask.BLL.Services;

public interface INodeService : IGenericService<NodeModel>
{
    Task DeleteAsync(string treeName, Guid nodeId, CancellationToken cancellationToken);
    Task<NodeModel> RenameNode(string treeName, Guid nodeId, string newNodeName, CancellationToken cancellationToken);
}

public class NodeService(INodeRepository repository, ITreeRepository treeRepository) : GenericService<NodeModel, NodeEntity>(repository), INodeService
{
    public override async Task<NodeModel> CreateAsync(NodeModel nodeModel, CancellationToken cancellationToken)
    {
        var treeEntity = await treeRepository.GetByNameAsync(nodeModel.TreeName, cancellationToken) ?? throw new TreeNotFoundException(nodeModel.TreeName);;
        
        if(nodeModel.ParentNodeId is not null)
        {
            var parentEntity = await _repository.GetByIdAsync(nodeModel.ParentNodeId.Value, cancellationToken: cancellationToken) 
                               ?? throw new NodeNotFoundException(nodeModel.ParentNodeId.Value);
            
            if(parentEntity.TreeId != treeEntity.Id)
                throw new NodeTreeMismatchException(nodeModel.ParentNodeId.Value, treeEntity.Id);
        }

        nodeModel.TreeId = treeEntity.Id;
        
        var entityToCreate = nodeModel.Adapt<NodeEntity>();        
        var createdNodeEntity = await _repository.CreateAsync(entityToCreate, cancellationToken);        
        
        var createdNodeModel = new NodeModel
        {
            Id = createdNodeEntity.Id,
            Name = createdNodeEntity.Name,
            TreeName = createdNodeEntity.TreeName,
            TreeId = createdNodeEntity.TreeId,
            ParentNodeId = createdNodeEntity.ParentNodeId
        }; 
        
        return createdNodeModel;
    }

    public async Task DeleteAsync(string treeName, Guid nodeId, CancellationToken cancellationToken)
    {
        var treeEntity = await treeRepository.GetByNameAsync(treeName, cancellationToken) ?? throw new TreeNotFoundException(treeName);
        if(treeEntity.Nodes?.Any(n => n.Id == nodeId) is false) return;
        
        var entityToDelete = await _repository.GetByIdAsync(nodeId, cancellationToken: cancellationToken);
        if(entityToDelete is null) return;
        
        await _repository.DeleteByIdAsync(entityToDelete, cancellationToken);
    }

    public async Task<NodeModel> RenameNode(string treeName, Guid nodeId, string newNodeName, CancellationToken cancellationToken)
    {
        var treeEntity = await treeRepository.GetByNameAsync(treeName, cancellationToken) ?? throw new TreeNotFoundException(treeName);
        if(treeEntity.Nodes?.Any(n => n.Id == nodeId) is false) throw new NodeNotFoundInTreeException(nodeId, treeName);
        
        var entityToRename = _repository.GetByIdAsync(nodeId, trackChanges: true, cancellationToken: cancellationToken).Result ?? throw new NodeNotFoundException(nodeId);
        entityToRename.Name = newNodeName;
        
        var isNameUnique = await repository.IsNameInTheTreeUniqueAsync(treeName, newNodeName, cancellationToken);
        if (!isNameUnique) throw new DuplicateNodeNameException(newNodeName, treeName);
        
        var updatedEntity = await _repository.UpdateAsync(entityToRename, cancellationToken);
        var updatedModel = new NodeModel
        {
            Id = updatedEntity.Id,
            Name = updatedEntity.Name,
            TreeName = updatedEntity.TreeName,
            TreeId = updatedEntity.TreeId,
            ParentNodeId = updatedEntity.ParentNodeId
        };
        return updatedModel;
    }
}