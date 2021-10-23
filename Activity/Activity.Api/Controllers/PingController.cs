using Activity.Api.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        public PingController()
        {
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<response<string>> Get()
        {
            try
            {
                return new response<string> { status = status.ok, data = "Api conectado correctamente! ◕_◕" };
            }
            catch (Exception ex)
            {
                return new response<string> { status = status.error, message = ex.Message };
            }
        }
    }

}
