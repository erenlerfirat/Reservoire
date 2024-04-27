﻿using Business.Abstract;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using Utiliy.Helper;
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

            return Ok(request);
        }
    }
}
