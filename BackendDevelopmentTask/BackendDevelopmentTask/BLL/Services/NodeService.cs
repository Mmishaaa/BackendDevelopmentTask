using BackendDevelopmentTask.BLL.Models;
using BackendDevelopmentTask.DAL.Entities;
using BackendDevelopmentTask.DAL.Repositories;

namespace BackendDevelopmentTask.BLL.Services;

public interface INodeService : IGenericService<NodeModel>;

public class NodeService(INodeRepository repository) : GenericService<NodeModel, NodeEntity>(repository), INodeService;