using Domain.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Utiliy.Abstract;

namespace Utiliy.Helper
{
    public class JwtHelper : IJwtHelper
    {
        public string SecretKey = AppSettingsHelper.GetValue("Token","");

        public string CreateToken(UserTokenRequest request, int expirationMinutes = 10080)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new(ClaimTypes.NameIdentifier, request.UserId.ToString()),
                new(ClaimTypes.Email, request.Email),
                new(ClaimTypes.Name, request.FirstName),
                new(ClaimTypes.Surname, request.LastName),
                new(ClaimTypes.Role, request.RoleType.ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(expirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal DecodeToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = SymmetricKeyHelper.GetSymmetricKey(),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
                return principal;
            }
            catch (SecurityTokenExpiredException)
            {
                // Token has expired
                return null;
            }
            catch (SecurityTokenInvalidSignatureException)
            {
                // Invalid token signature
                return null;
            }
            catch (Exception)
            {
                // Other token validation errors
                return null;
            }
        }
        public IEnumerable<Claim> GetClaims()
        {
            throw new NotImplementedException();
        }

    }
    public static class SymmetricKeyHelper
    {
        public static SymmetricSecurityKey GetSymmetricKey()
        {
            var key = Encoding.ASCII.GetBytes(AppSettingsHelper.GetValue("Token", ""));
            return new SymmetricSecurityKey(key);
        }
    }
}
