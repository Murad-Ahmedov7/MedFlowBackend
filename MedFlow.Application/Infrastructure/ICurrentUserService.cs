

using Domain.Entities.Auth.Enums;

namespace Application.Infrastructure;

/// <summary>
/// Cari istifadəçi məlumatlarını təmin edən servis
/// </summary>
public interface ICurrentUserService
{
    Guid? GetCurrentUserId();
    Guid GetCurrentUserIdOrThrow();
    string? GetCurrentUserEmail();
    UserRoles GetCurrentUserRoleOrThrow();
    bool IsAuthenticated();
}
