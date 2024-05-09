using Business.Abstract;
using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utility.Results;
using Utiliy.Models;

namespace Reservoire.Controllers
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {   private readonly ILoginService loginService;
        private readonly IConfiguration configuration;
        public LoginController(IConfiguration configuration, ILoginService loginService)
        {
            this.loginService = loginService;
            this.configuration = configuration;
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
