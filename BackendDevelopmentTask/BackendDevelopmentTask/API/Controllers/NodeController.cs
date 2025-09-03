using BackendDevelopmentTask.API.Dtos.Requests;
using BackendDevelopmentTask.API.Dtos.Responses;
using BackendDevelopmentTask.BLL.Models;
using BackendDevelopmentTask.BLL.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BackendDevelopmentTask.API.Controllers;

[ApiController]
[Route("api.user.tree.node")]
public class NodeController(INodeService nodeService) : ControllerBase
{
    [HttpPost(".create")]
    public async Task<CreateNodeResponseDto> CreateNode([FromQuery] CreateNodeRequestDto request, CancellationToken cancellationToken)
    {
        var nodeModelToCreate = request.Adapt<NodeModel>();
        var nodeModel = await nodeService.CreateAsync(nodeModelToCreate, cancellationToken);
        return nodeModel.Adapt<CreateNodeResponseDto>();
    }
}