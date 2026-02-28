using Domain.Entities.Base;

namespace Domain.Entities.Auth
{
    public class User:BaseEntity
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        public ICollection<RefreshToken> RefreshTokens { get; set; } = null!;


    }
}
