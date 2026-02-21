

using Domain.Entities;

namespace Application.Infrastructure;

    public interface ITokenProvider
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
    }

