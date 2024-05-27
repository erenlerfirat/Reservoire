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

        public UserDetailsDto GetUserDetails(string token)
        {
            token = token.Split(" ")[1]; // Cut Bearer prefix

            var tokenHandler = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = SymmetricKeyHelper.GetSymmetricKey(),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };

            var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
            var userDetails = ToUserDetails(principal);
            return userDetails;
            
        }
        private static UserDetailsDto ToUserDetails(ClaimsPrincipal principal) 
        {
            var id = Convert.ToInt32(principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var firstname = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var lastname = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value;
            var roleType = Convert.ToInt16(principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value);
            var email = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            return new UserDetailsDto
            {
                Id = id,
                Email = email ?? "",
                RoleType = roleType,
                FirstName = firstname ?? "",
                LastName = lastname ?? ""
            };
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
