using Domain.Dtos;
using Utility.Results;

namespace Business.Abstract
{
    public interface IAuthService
    {
        public Task<IDataResult<LoginResponse>> LoginAsync(LoginRequest request);        
        public Task<IDataResult<RegisterResponse>> RegisterAsync(RegisterRequest request);
        public Task<IDataResult<bool>> UpdatePasswordAsync(string username, string password);
        public IDataResult<UserDetailsDto> GetUserDetails(string token);
    }
}
