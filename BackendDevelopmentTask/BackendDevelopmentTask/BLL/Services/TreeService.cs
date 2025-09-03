using BackendDevelopmentTask.BLL.Models;
using BackendDevelopmentTask.DAL.Entities;
using BackendDevelopmentTask.DAL.Repositories;

namespace BackendDevelopmentTask.BLL.Services;

public interface ITreeService : IGenericService<TreeModel>;

public class TreeService(ITreeRepository repository) : GenericService<TreeModel, TreeEntity>(repository), ITreeService;