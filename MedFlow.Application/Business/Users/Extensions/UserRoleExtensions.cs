using Domain.Entities.Auth.Enums;


namespace Application.Business.Users.Extensions;

public static class UserRoleExtensions
{
    private static readonly Dictionary<UserRoles, UserRoles[]> CreatePermissions = new Dictionary<UserRoles, UserRoles[]>()
    {
        //{UserRoles.Admin,new UserRoles[] {UserRoles.Admin,UserRoles.Receptionist,UserRoles.Patient,UserRoles.Doctor}},

        {UserRoles.Admin,new UserRoles[] {UserRoles.Receptionist,UserRoles.Doctor}},

        {UserRoles.Receptionist,new UserRoles[] {UserRoles.Patient} }
    };

    public static bool CanCreate( this UserRoles currentRole, UserRoles targetRole)
    {
        return CreatePermissions.TryGetValue(currentRole, out var allowedRoles)
               && allowedRoles.Contains(targetRole);
    }

}