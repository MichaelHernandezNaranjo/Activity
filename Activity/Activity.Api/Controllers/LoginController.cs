using Activity.Api.Responses;
using Activity.Core.Entities;
using Activity.Core.Exceptions;
using Activity.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Activity.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;
        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post(authenticationRequest _authenticationRequest)
        {
            try
            {
                var res = await _authService.Authentication(_authenticationRequest);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Ping")]
        public async Task<IActionResult> GetPing()
        {
            try
            {
                return Ok("Api conectado correctamente! ◕_◕");
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("Session")]
        public async Task<IActionResult> GetSession()
        {
            try
            {
                var rolesClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserName").Value;

                return Ok("Api conectado correctamente! ◕_◕");
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

    }

}
