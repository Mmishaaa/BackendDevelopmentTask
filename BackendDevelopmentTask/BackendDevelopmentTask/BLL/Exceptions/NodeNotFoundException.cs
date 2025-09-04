namespace BackendDevelopmentTask.BLL.Exceptions;

public class NodeNotFoundException(Guid nodeId)
    : SecureException($"Node with ID '{nodeId}' does not exist.");