using Business.Abstract;
using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utility.Results;

namespace ReservoireApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route("/{id}")]
        public async Task<IDataResult<UserDto>> GetUser(int id)
        {
            var result = await userService.GetUser(id);
            return result.Success
                   ? new SuccessDataResult<UserDto>(result.Data)
                   : new ErrorDataResult<UserDto>(result.Message);
            
        }
    }
}
