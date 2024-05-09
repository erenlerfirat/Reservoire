using Domain.Dtos;
using Utility.Results;

namespace Business.Abstract
{
    public interface ILoginService
    {
        public IDataResult<LoginResponse> Login(LoginRequest request);        
        public IDataResult<RegisterResponse> Register(RegisterRequest request);
        public IDataResult<bool> UpdatePassword(string username, string password);
        public IDataResult<UserDetailsDto> GetUserDetails(string token);
    }
}
