namespace BackendDevelopmentTask.BLL.Exceptions;

public class DuplicateNodeNameException(string nodeName, string treeName)
    : SecureException($"Node with name '{nodeName}' already exists in tree '{treeName}'.");