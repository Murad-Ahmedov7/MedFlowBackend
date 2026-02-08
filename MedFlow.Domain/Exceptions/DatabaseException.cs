namespace Domain.Exceptions;

public class DatabaseException : ApplicationException
{
    public int Code { get; }

    public DatabaseException(string message, int code = 0) : base(message)
    {
        Code = code;
    }
}
