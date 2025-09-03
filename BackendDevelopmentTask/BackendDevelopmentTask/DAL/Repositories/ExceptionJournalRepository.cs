using BackendDevelopmentTask.DAL.Entities;

namespace BackendDevelopmentTask.DAL.Repositories;

public interface IExceptionJournalRepository : IGenericRepository<ExceptionJournalEntity>;

public class ExceptionJournalRepository(ApplicationDbContext context) 
    : GenericRepository<ExceptionJournalEntity>(context), IExceptionJournalRepository;