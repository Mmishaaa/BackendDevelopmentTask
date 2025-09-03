namespace BackendDevelopmentTask.BLL.Exceptions;

public class NodeNotFoundInTreeException(Guid nodeId, string treeName)
    : SecureException($"Node with ID '{nodeId}' does not exist in tree '{treeName}'.");