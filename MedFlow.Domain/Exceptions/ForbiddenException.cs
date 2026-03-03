
namespace Domain.Exceptions;
public class ForbiddenException:ApplicationException
{
    public IEnumerable<string> Errors { get; private set; } = [];

    public ForbiddenException(string error)
    {
        Errors = [error];
    }

    public ForbiddenException(IEnumerable<string> errors)
    {
        Errors = errors;
    }
}
