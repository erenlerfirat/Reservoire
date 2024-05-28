using Business.Abstract;
using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Utility.Results;
using Utiliy.Models;

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
        public async Task<IDataResult<LoginResponse>> Login([FromBody] LoginRequest request , CancellationToken cancellationToken)
        {
            var result = await loginService.LoginAsync(request, cancellationToken);
            return result.Success
                   ? new SuccessDataResult<LoginResponse>(result.Data,result.Message)
                   : new ErrorDataResult<LoginResponse>(result.Message);
        }
        [HttpPost("Register")]
        public async Task<IDataResult<RegisterResponse>> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
        {
            var result = await loginService.RegisterAsync(request, cancellationToken);
            return result.Success
                   ? new SuccessDataResult<RegisterResponse>(result.Message)
                   : new ErrorDataResult<RegisterResponse>(result.Message);
        }
        
        [HttpGet("Test")]
        public async Task<ActionResult<string>> Test(CancellationToken cancellationToken)
        {
            try
            {

                for (int i = 0; i < 100; i++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await Task.Delay(200);
                    Console.WriteLine($"{i}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
            

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
