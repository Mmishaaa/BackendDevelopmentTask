namespace BackendDevelopmentTask.BLL.Exceptions;

public class TreeNotFoundException(string treeName) : SecureException($"Tree with name '{treeName}' does not exist.");