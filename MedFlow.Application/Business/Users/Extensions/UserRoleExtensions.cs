using Domain.Entities.Auth.Enums;


namespace Application.Business.Users.Extensions;

public static class UserRoleExtensions
{
    private static readonly Dictionary<UserRole, UserRole[]> CreatePermissions = new Dictionary<UserRole, UserRole[]>()
    {
        //{UserRoles.Admin,new UserRoles[] {UserRoles.Admin,UserRoles.Receptionist,UserRoles.Patient,UserRoles.Doctor}},

        {UserRole.Admin,new UserRole[] {UserRole.Receptionist,UserRole.Doctor}},

        {UserRole.Receptionist,new UserRole[] {UserRole.Patient} }
    };

    public static bool CanCreate( this UserRole currentRole, UserRole targetRole)
    {
        return CreatePermissions.TryGetValue(currentRole, out var allowedRoles)
               && allowedRoles.Contains(targetRole);
    }

}