namespace Domain.Exceptions;

public class DatabaseException : ApplicationException
{
    public int Code { get; }

    // Verilənlər bazası əməliyyatları zamanı baş verən
    // tətbiq səviyyəli xətaları təmsil edir.
    // Xəta mesajı və opsional error kodu saxlayır.
    //
    // Represents application-level errors that occur
    // during database operations.
    // Stores an error message and an optional error code.

    public DatabaseException(string message, int code = 0) : base(message)
    {
        Code = code;
    }
}
