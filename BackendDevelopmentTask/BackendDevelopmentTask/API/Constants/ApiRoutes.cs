namespace BackendDevelopmentTask.API.Constants;

public class ApiRoutes
{
    private const string ApiUser = "api.user";
    private const string ApiUserTree = $"{ApiUser}.tree";
    private const string ApiUserTreeNode = $"{ApiUserTree}.node";
    private const string ApiUserJournal = "api.user.journal";
    
    public const string GetTreeEndpoint = $"{ApiUserTree}.get";
    public const string CreateNodeEndpoint = $"{ApiUserTreeNode}.create";
    public const string DeleteNodeEndpoint = $"{ApiUserTreeNode}.delete";
    public const string RenameNodeEndpoint = $"{ApiUserTreeNode}.rename";
    
    public const string JournalGetRangeEndpoint = $"{ApiUserJournal}.getRange";
    public const string JournalGetSingleEndpoint = $"{ApiUserJournal}.getSingle";
}