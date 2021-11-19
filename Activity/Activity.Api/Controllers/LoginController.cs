using Activity.Api.Responses;
using Activity.Core.Entities;
using Activity.Core.Exceptions;
using Activity.Core.Interfaces;
using Activity.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Activity.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly AppSettings _appSettings;
        public LoginController(IAuthService authService, IOptions<AppSettings> appSettings)
        {
            _authService = authService;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post(authenticationRequest _authenticationRequest)
        {
            try
            {
                var res = await _authService.Authentication(_authenticationRequest);
                string Token = generateJwtToken(res);
                var res_ = new
                {
                    CompanyId = res.CompanyId,
                    UserId = res.UserId,
                    UserName = res.UserName,
                    Email = res.Email,
                    RoleId = res.RoleId,
                    RoleName = res.RoleName,
                    Token = Token
                };
                return Ok(res_);
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
                authenticationResponse res = securityService.UserClaim(HttpContext);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        private string generateJwtToken(authenticationResponse entity)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(Core.Constant.General.ClaimTypeUser,securityService.JsonSerialize(entity)),
                }),
                Expires = DateTime.UtcNow.AddHours(_appSettings.AuthTimeHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }

}
