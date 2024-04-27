using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Utiliy.Abstract;

namespace Utiliy.Models
{
    public class JWTContainerModel : IAuthContainerModel
    {
        public int ExpireMinutes { get; set; } = 10080; // 7 days.
        public string SecretKey { get; set; } 
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;
        public Claim[] Claims { get; set; }
        
    }
}
