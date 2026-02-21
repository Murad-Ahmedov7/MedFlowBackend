namespace Domain.Exceptions;

public class ServerException : ApplicationException
{
    // Server tərəfində baş verən ümumi tətbiq səviyyəli xətaları təmsil edir.
    // Server-dən qaynaqlanan və spesifik olmayan problemlər üçün istifadə olunur.
    //

    // Represents general application-level errors that occur on the server side.
    // Used for non-specific server-related failures.

    public ServerException(string message) : base(message)
    {
    }
}