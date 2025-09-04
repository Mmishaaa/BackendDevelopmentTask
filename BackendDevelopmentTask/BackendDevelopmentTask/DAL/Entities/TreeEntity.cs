namespace BackendDevelopmentTask.DAL.Entities;

public class TreeEntity : BaseEntity
{
    public string Name { get; set; } = null!;

    public List<NodeEntity>? Nodes { get; set; }
}