using Domain.Dtos;
using Utility.Results;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<UserDto>> GetUser(int userId);

        Task<IResult> AddUserAddress(int userId);
    }
}