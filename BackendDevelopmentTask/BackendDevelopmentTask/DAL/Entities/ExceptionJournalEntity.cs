namespace BackendDevelopmentTask.DAL.Entities;

public class ExceptionJournalEntity : BaseEntity
{
    public Guid EventId { get; set; }
    public DateTime Timestamp { get; set; }
    public string? QueryParametersJson { get; set; }
    public string? BodyParametersJson { get; set; }
    public string? StackTrace { get; set; }
    public string? ExceptionType { get; set; }
    public string? ExceptionMessage { get; set; }
}