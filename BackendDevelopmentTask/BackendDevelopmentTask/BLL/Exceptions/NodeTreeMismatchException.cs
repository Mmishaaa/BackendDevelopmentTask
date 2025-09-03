namespace BackendDevelopmentTask.BLL.Exceptions;

public class NodeTreeMismatchException(Guid parentNodeId, Guid expectedTreeId)
    : SecureException($"Parent node '{parentNodeId}' belongs to another tree (expected tree ID: {expectedTreeId}).");