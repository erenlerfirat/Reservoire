using Business.Abstract;
using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utility.Results;

namespace Reservoire.Controllers
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {   
        private readonly IAuthService loginService;
        public AuthController(IAuthService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost("Login")]
        public async Task<IDataResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            var result = await loginService.LoginAsync(request);
            return result.Success
                   ? new SuccessDataResult<LoginResponse>(result.Data,result.Message)
                   : new ErrorDataResult<LoginResponse>(result.Message);
        }
        [HttpPost("Register")]
        public async Task<IDataResult<RegisterResponse>> Register([FromBody] RegisterRequest request)
        {
            var result = await loginService.RegisterAsync(request);
            return result.Success
                   ? new SuccessDataResult<RegisterResponse>(result.Message)
                   : new ErrorDataResult<RegisterResponse>(result.Message);
        }
        
        [HttpGet("Test")]
        public ActionResult<string> Test()
        {
            return Ok("Slavek");
        }

        [Authorize]
        [HttpGet("TestAuth")]
        public ActionResult<string> TestAuth([FromHeader(Name = "Authorization")] string token)
        {
            var result = loginService.GetUserDetails(token);
            return Ok("Slavek");
        }
    }
}
