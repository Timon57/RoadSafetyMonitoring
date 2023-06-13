using Microsoft.AspNetCore.Identity;

namespace RoadSafety.Repository
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
