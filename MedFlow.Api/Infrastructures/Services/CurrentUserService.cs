using Application.Infrastructure;
using Domain.Entities.Auth.Enums;
using System.Security.Claims;

namespace MedFlow.Api.Infrastructures.Services;
internal class CurrentUserService : ICurrentUserService
{
    private static readonly Guid DefaultSystemUserId = Guid.Parse("00000000-0000-0000-0000-000000000001");
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? GetCurrentUserId()
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrWhiteSpace(userIdClaim))
            return DefaultSystemUserId;

        return Guid.TryParse(userIdClaim, out var userId) ? userId : DefaultSystemUserId;
    }

    public Guid GetCurrentUserIdOrThrow()
    {
        return GetCurrentUserId() ?? DefaultSystemUserId;
    }

    public string? GetCurrentUserEmail()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;
    }

    public UserRoles GetCurrentUserRoleOrThrow()
    {
        var roleClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value;

        if (string.IsNullOrWhiteSpace(roleClaim))
        {
            throw new UnauthorizedAccessException("User role claim not found");
        }

        if(!Enum.TryParse<UserRoles>(roleClaim,true,out var role))
        {
            throw new UnauthorizedAccessException("Invalid User Role");
        }
        return role;
    }

    public bool IsAuthenticated()
    {
        return _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }

}
