using Business.Abstract;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<Token> Login([FromBody] LoginRequest request)
        {
            loginService.Login(request);
            return Ok(request);
        }
        [HttpPost("Register")]
        public ActionResult<Token> Register([FromBody] LoginRequest request)
        {
            return Ok(request);
        }

        [HttpGet("Test")]
        public ActionResult<string> Test()
        {
            return Ok("Slavek");
        }
    }
}
