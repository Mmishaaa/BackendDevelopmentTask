using BackendDevelopmentTask.DAL.Entities;

namespace BackendDevelopmentTask.DAL.Repositories;

public interface ITreeRepository : IGenericRepository<TreeEntity>;

public class TreeRepository(ApplicationDbContext context) : GenericRepository<TreeEntity>(context), ITreeRepository;