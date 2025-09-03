using BackendDevelopmentTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendDevelopmentTask.DAL;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<NodeEntity> Nodes { get; init; }
    public DbSet<TreeEntity> Trees { get; init; }
    public DbSet<ExceptionJournalEntity> ExceptionsJournal { get; init; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<NodeEntity>()
            .HasOne(n => n.ParentNode)
            .WithMany(n => n.ChildNodes)
            .HasForeignKey(n => n.ParentNodeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}