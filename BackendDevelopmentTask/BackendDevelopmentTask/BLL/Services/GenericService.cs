using BackendDevelopmentTask.BLL.Models;
using BackendDevelopmentTask.DAL.Entities;
using BackendDevelopmentTask.DAL.Repositories;
using Mapster;

namespace BackendDevelopmentTask.BLL.Services;

public interface IGenericService<TModel> where TModel : BaseModel
{
    Task<TModel> CreateAsync(TModel model, CancellationToken cancellationToken);
    Task<TModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<TModel>> GetAllAsync(CancellationToken cancellationToken);
    Task<TModel> UpdateAsync(Guid id, TModel model, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<PagedEntityModel<TModel>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
}

public class GenericService<TModel, TEntity> : IGenericService<TModel> where TModel : BaseModel where TEntity : BaseEntity
{
    protected IGenericRepository<TEntity> _repository;

    public GenericService(IGenericRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public virtual async Task<TModel> CreateAsync(TModel model, CancellationToken cancellationToken)
    {
        var modelToCreate = model.Adapt<TEntity>();
        var entity = await _repository.CreateAsync(modelToCreate, cancellationToken);
        return entity.Adapt<TModel>();
    }

    public virtual async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entityToDelete = await _repository.GetByIdAsync(id, cancellationToken: cancellationToken);
        if(entityToDelete is null) return;
        await _repository.DeleteByIdAsync(entityToDelete, cancellationToken);
    }

    public virtual async Task<List<TModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken: cancellationToken);
        return entities.Adapt<List<TModel>>();
    }

    public virtual async Task<TModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken: cancellationToken) ?? throw new Exception("Entity with this id doesn't exist");
        return entity.Adapt<TModel>();
    }

    public virtual async Task<TModel> UpdateAsync(Guid id, TModel model, CancellationToken cancellationToken)
    {
        _ = await _repository.GetByIdAsync(id, cancellationToken: cancellationToken) ?? throw new Exception("Entity with this id doesn't exist"); ;
        var newEntity = model.Adapt<TEntity>();
        newEntity.Id = id;
        await _repository.UpdateAsync(newEntity, cancellationToken);
        return newEntity.Adapt<TModel>();
    }
    
    public virtual async Task<PagedEntityModel<TModel>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetPagedAsync(pageNumber, pageSize, cancellationToken);

        var entitiesModel = entities.Adapt<PagedEntityModel<TModel>>();

        return entitiesModel;
    }
}