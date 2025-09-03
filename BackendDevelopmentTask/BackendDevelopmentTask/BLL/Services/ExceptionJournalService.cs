using BackendDevelopmentTask.BLL.Models;
using BackendDevelopmentTask.DAL.Entities;
using BackendDevelopmentTask.DAL.Repositories;

namespace BackendDevelopmentTask.BLL.Services;

public interface IExceptionJournalService : IGenericService<ExceptionJournalModel>;

public class ExceptionJournalService(IExceptionJournalRepository repository) 
    : GenericService<ExceptionJournalModel, ExceptionJournalEntity>(repository), IExceptionJournalService;