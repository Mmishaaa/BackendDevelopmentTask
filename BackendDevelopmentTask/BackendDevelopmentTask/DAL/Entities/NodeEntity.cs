namespace BackendDevelopmentTask.DAL.Entities;

public class NodeEntity : BaseEntity
{
    public string Name { get; set; } = null!;

    public string TreeName { get; set; } = null!;
    public Guid TreeId { get; set; }
    public TreeEntity Tree { get; set; } = null!;
    
    public Guid? ParentNodeId { get; set; }
    public NodeEntity? ParentNode { get; set; }

    public List<NodeEntity>? ChildNodes { get; set; }
}