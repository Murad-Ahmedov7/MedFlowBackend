using Domain.Exceptions;
using MediatR;

namespace Application.Infrastructure;

public abstract class SysRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    protected readonly ICurrentUserService? CurrentUserService;

    protected SysRequestHandler(ICurrentUserService? currentUserService = null)
    {
        CurrentUserService = currentUserService;
    }

    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

    protected void ThrowUserErrorIfNull(object? data, string message = "Məlumat tapılmadı")
    {
        if (data == null)
        {
            throw new ClientException(message);
        }
    }

    protected void ThrowUserError(string message)
    {
        throw new ClientException(message);
    }

    protected Guid? GetCurrentUserId()
    {
        return CurrentUserService?.GetCurrentUserId();
    }

    protected Guid GetCurrentUserIdOrThrow()
    {
        if (CurrentUserService == null)
            throw new UnauthorizedAccessException("İstifadəçi autentifikasiya olunmayıb");

        return CurrentUserService.GetCurrentUserIdOrThrow();
    }
}
