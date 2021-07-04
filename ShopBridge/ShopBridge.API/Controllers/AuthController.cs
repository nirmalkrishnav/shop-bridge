using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.DTOs;
using ShopBridge.Interfaces.Service;

namespace ShopBridge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IAuthService _authService;
        public AuthController(
            IAuthService authService
            )
        {
            _authService = authService;
        }
       
        [HttpPost("register")]
        public async Task<bool> Register(User user)
        {
            return await _authService.Register(user);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<TokenResult> Login(TokenRequest model)
        {
            return await _authService.Login(model);
        }
    }
}
