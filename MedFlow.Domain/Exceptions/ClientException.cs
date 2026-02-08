namespace Domain.Exceptions;

public class ClientException : ApplicationException
{
    public IEnumerable<string> Errors { get; private set; } = [];

    public ClientException(string error)
    {
        Errors = [error];
    }

    public ClientException(IEnumerable<string> errors)
    {
        Errors = errors;
    }
}
