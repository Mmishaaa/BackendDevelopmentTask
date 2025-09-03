using BackendDevelopmentTask.API.Constants;
using BackendDevelopmentTask.API.Dtos.Requests;
using BackendDevelopmentTask.API.Dtos.Responses;
using BackendDevelopmentTask.BLL.Models;
using BackendDevelopmentTask.BLL.Services;
using BackendDevelopmentTask.DAL.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BackendDevelopmentTask.API.Controllers;

[ApiController]
public class TreesController(ITreeService treeService, INodeService nodeService) : ControllerBase
{
    [HttpPost($"{ApiRoutes.GetTreeEndpoint}")]
    public async Task<TreeEntity> GetTreeAsync([FromQuery] string treeName, CancellationToken cancellationToken)
    {
        var tree = await treeService.GetByNameAsync(treeName, cancellationToken);
        return tree;
    }
    
    [HttpPost($"{ApiRoutes.CreateNodeEndpoint}")]
    public async Task<CreateNodeResponseDto> CreateNodeAsync([FromQuery] CreateNodeRequestDto request, CancellationToken cancellationToken)
    {
        var nodeModelToCreate = request.Adapt<NodeModel>();
        var nodeModel = await nodeService.CreateAsync(nodeModelToCreate, cancellationToken);
        return nodeModel.Adapt<CreateNodeResponseDto>();
    }
    
    [HttpPost($"{ApiRoutes.DeleteNodeEndpoint}")]
    public async Task DeleteNodeAsync([FromQuery] string treeName, Guid nodeId, CancellationToken cancellationToken)
    {
        await nodeService.DeleteAsync(treeName, nodeId, cancellationToken);
    }
    
    [HttpPost($"{ApiRoutes.RenameNodeEndpoint}")]
    public async Task<RenameNodeResponseDto> RenameNodeAsync([FromQuery] string treeName, Guid nodeId, string newNodeName, CancellationToken cancellationToken)
    {
        var updatedNodeModel = await nodeService.RenameNode(treeName, nodeId, newNodeName, cancellationToken);
        return updatedNodeModel.Adapt<RenameNodeResponseDto>();
    }
}