namespace Domain.Exceptions;

public class ServerException : ApplicationException
{
    public ServerException(string message) : base(message)
    {
    }
}