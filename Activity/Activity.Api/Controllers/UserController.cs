using Activity.Core.Entities;
using Activity.Core.Exceptions;
using Activity.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activity.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService2<userRequest, userResponse> _service;
        public UserController(IService2<userRequest, userResponse> service)
        {
            _service = service;
        }

        [HttpGet("{CompanyId}")]
        public async Task<IActionResult> GetAll(int CompanyId)
        {
            try
            {
                var res = await _service.GetAll(CompanyId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        [HttpGet("{CompanyId}/{UserId}")]
        public async Task<IActionResult> GetById(int CompanyId, int UserId)
        {
            try
            {
                var res = await _service.GetById(CompanyId, UserId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(userRequest entity)
        {
            try
            {
                var res = await _service.Add(entity);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(userRequest entity)
        {
            try
            {
                var res = await _service.Update(entity);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }


    }
}
