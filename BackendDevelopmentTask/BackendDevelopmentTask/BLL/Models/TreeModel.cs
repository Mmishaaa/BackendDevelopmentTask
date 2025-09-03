namespace BackendDevelopmentTask.BLL.Models;

public class TreeModel : BaseModel
{
    public string Name { get; set; } = null!;

    public List<NodeModel>? Nodes { get; set; }
}