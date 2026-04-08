
using Domain.Entities.Auth.Enums;
using Domain.Entities.Base;
using Domain.Entities.Doctors;

namespace Domain.Entities.Auth;

public class User : BaseEntity
{
    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public UserRole UserRole { get; set; }

    public ICollection<RefreshToken> RefreshTokens { get; set; } = null!;

    public Doctor? Doctor { get; set; }
}
