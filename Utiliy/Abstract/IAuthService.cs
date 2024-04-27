using System.Security.Claims;

namespace Utiliy.Abstract
{
    public interface IAuthService
    {
        bool IsTokenValid(string token);
        string GenerateToken(IAuthContainerModel model);
        IEnumerable<Claim> GetTokenClaims(string token);
    }
}
