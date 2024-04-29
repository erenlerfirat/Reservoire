using Domain.Dtos;
using System.Security.Claims;

namespace Utiliy.Abstract
{
    public interface IJwtHelper
    {
        string CreateToken(UserTokenRequest request, int expirationMinutes = 10080);
        ClaimsPrincipal DecodeToken(string token);
    }
}
