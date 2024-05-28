using Domain.Dtos;
using Utility.Results;

namespace Business.Abstract
{
    public interface IAuthService
    {
        public Task<IDataResult<LoginResponse>> LoginAsync(LoginRequest request, CancellationToken cancellationToken);        
        public Task<IDataResult<RegisterResponse>> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken);
        public Task<IDataResult<bool>> UpdatePasswordAsync(string username, string password, CancellationToken cancellationToken);
        public IDataResult<UserDetailsDto> GetUserDetails(string token);
    }
}
