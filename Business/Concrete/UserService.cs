using Business.Abstract;
using Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using Utility.Results;
using Utiliy.Messages;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly CoreDbContext coreDbContext;
        public UserService(CoreDbContext coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public Task<IResult> AddUserAddress(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<UserDto>> GetUser(int userId)
        {
            var user = await coreDbContext.User.Where(x => x.Id == userId)
                              .Include(x => x.UserAddress)
                              .FirstAsync();
            if (user is null)            
                return new ErrorDataResult<UserDto>(Messages.NotFound);
            
            var userDto = new UserDto() { FirstName = user.FirstName, LastName = user.LastName ,UserAddress = user?.UserAddress};
            
            return new SuccessDataResult<UserDto>(userDto);
        }
    }
}
