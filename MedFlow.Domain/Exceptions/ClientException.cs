namespace Domain.Exceptions;

public class ClientException : ApplicationException
{
    // Client (istifadəçi) tərəfindən göndərilən sorğularda yaranan
    // application-level xətaları təmsil edir.
    // Bu xətalar sistem deyil, tətbiq məntiqi səviyyəsində
    // şüurlu şəkildə atılır.
    // Bir və ya bir neçə xəta mesajını collection şəklində saxlayır və
    // error-ların kənardan dəyişdirilməsinə icazə vermir.
    //
    // Represents application-level errors caused by invalid client requests.
    // These errors are intentionally thrown by the application logic,
    // not by the runtime or system.
    // Stores one or more error messages as a read-only collection
    // to prevent external modification.
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
