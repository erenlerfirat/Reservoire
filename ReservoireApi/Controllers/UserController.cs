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
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("GetUser")]
        public async Task<IDataResult<UserDto>> GetUser(int id)
        {
            var result = await userService.GetUser(id);
            return result.Success
                   ? new SuccessDataResult<UserDto>(result.Data)
                   : new ErrorDataResult<UserDto>(result.Message);
            
        }        
    }
}
