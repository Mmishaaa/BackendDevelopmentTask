using BackendDevelopmentTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendDevelopmentTask.DAL;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<NodeEntity> Nodes { get; init; }
    public DbSet<TreeEntity> Trees { get; init; }
    public DbSet<ExceptionJournalEntity> ExceptionsJournal { get; init; }
}