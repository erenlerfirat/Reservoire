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
    public class LoginController : ControllerBase
    {   
        private readonly ILoginService loginService;
        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }
        [HttpPost("Login")]
        public IDataResult<LoginResponse> Login([FromBody] LoginRequest request)
        {
            var result = loginService.Login(request);
            return result.Success
                   ? new SuccessDataResult<LoginResponse>(result.Data)
                   : new ErrorDataResult<LoginResponse>();
        }
        [HttpPost("Register")]
        public IDataResult<RegisterResponse> Register([FromBody] RegisterRequest request)
        {
            var result = loginService.Register(request);
            return result.Success
                   ? new SuccessDataResult<RegisterResponse>()
                   : new ErrorDataResult<RegisterResponse>(result.Data);
        }
        [Authorize]
        [HttpGet("Test")]
        public ActionResult<string> Test()
        {
            return Ok("Slavek");
        }
    }
}
