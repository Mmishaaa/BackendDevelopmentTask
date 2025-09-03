namespace BackendDevelopmentTask.API.Constants;

public class ApiRoutes
{
    private const string ApiUser = "api.user";
    private const string ApiUserTree = $"{ApiUser}.tree";
    private const string ApiUserTreeNode = $"{ApiUserTree}.node";
    
    public const string GetTreeEndpoint = $"{ApiUserTree}.get";
    public const string CreateNodeEndpoint = $"{ApiUserTreeNode}.create";
    public const string DeleteNodeEndpoint = $"{ApiUserTreeNode}.delete";
    public const string RenameNodeEndpoint = $"{ApiUserTreeNode}.rename";
}