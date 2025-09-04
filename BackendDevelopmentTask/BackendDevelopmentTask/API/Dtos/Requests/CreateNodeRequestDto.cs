namespace BackendDevelopmentTask.API.Dtos.Requests;

public class CreateNodeRequestDto
{
    public string Name { get; set; } = null!;
    public string TreeName { get; set; } = null!;
    
    public Guid? ParentNodeId { get; set; }
}