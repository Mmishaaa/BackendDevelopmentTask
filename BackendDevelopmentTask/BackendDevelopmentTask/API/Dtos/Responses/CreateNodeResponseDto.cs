namespace BackendDevelopmentTask.API.Dtos.Responses;

public class CreateNodeResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string TreeName { get; set; } = null!;
    public Guid TreeId { get; set; }
    public Guid? ParentNodeId { get; set; }
}