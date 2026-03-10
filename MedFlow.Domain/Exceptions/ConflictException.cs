

namespace Domain.Exceptions
{
    public class ConflictException : ApplicationException
    {
        public IEnumerable<string> Errors { get; private set; } = [];

        public ConflictException(string error)
        {
            Errors = [error];
        }

        public ConflictException(IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }
}
