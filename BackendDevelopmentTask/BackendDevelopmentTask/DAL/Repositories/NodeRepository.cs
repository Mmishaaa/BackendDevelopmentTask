using BackendDevelopmentTask.DAL.Entities;

namespace BackendDevelopmentTask.DAL.Repositories;

public interface INodeRepository : IGenericRepository<NodeEntity>;

public class NodeRepository(ApplicationDbContext context) : GenericRepository<NodeEntity>(context), INodeRepository;
