namespace BackendDevelopmentTask.BLL.Models;

public class NodeModel : BaseModel
{
    public string Name { get; set; } = null!;

    public Guid TreeId { get; set; }
    public TreeModel Tree { get; set; } = null!;
    
    public Guid? ParentNodeId { get; set; }
    public NodeModel? ParentNode { get; set; }

    public List<NodeModel>? ChildNodes { get; set; }
}