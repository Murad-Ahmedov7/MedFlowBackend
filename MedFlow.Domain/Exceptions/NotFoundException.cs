

namespace Domain.Exceptions;

public class NotFoundException : ApplicationException
{

    // Sorğu düzgün icra olunsa da, tələb olunan resursun
    // sistemdə mövcud olmadığı halları təmsil edir.
    // Bu xətalar client-in səhvi deyil, məlumatın
    // olmaması ilə bağlı application-level vəziyyətlərdir.
    // Adətən identity lookup əməliyyatlarında (məsələn, FIN ilə axtarış)
    // şüurlu şəkildə atılır.
    // Bir və ya bir neçə xəta mesajını collection şəklində saxlayır və
    // error-ların kənardan dəyişdirilməsinə icazə vermir.
    //
    // Represents application-level cases where the request is valid,
    // but the requested resource does not exist.
    // These errors are not caused by invalid client input,
    // but by missing data in the system.
    // Typically thrown intentionally during identity lookup operations
    // (e.g. search by FIN).
    // Stores one or more error messages as a read-only collection
    // to prevent external modification.
    public IEnumerable<string> Errors { get; private set; } = [];

    public NotFoundException(string error)
    {
        Errors = [error];
    }

    public NotFoundException(IEnumerable<string> errors)
    {
        Errors = errors;
    }
}

