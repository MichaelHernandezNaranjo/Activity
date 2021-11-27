using Activity.Core.Entities;
using Activity.Core.Exceptions;
using Activity.Core.Interfaces;
using Activity.Core.Services;
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
    public class TaskController : ControllerBase
    {
        private readonly IService3<taskRequest, taskResponse> _service;
        public TaskController(IService3<taskRequest, taskResponse> service)
        {
            _service = service;
        }
        [HttpGet("{ProjectId}")]
        public async Task<IActionResult> GetAll(int ProjectId)
        {
            try
            {
                authenticationResponse _auth = securityService.UserClaim(HttpContext);
                var res = await _service.GetAll(_auth.CompanyId, ProjectId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }
        [HttpGet("{ProjectId}/Where={Where}")]
        public async Task<IActionResult> GetWhere(int ProjectId, string Where)
        {
            try
            {
                authenticationResponse _auth = securityService.UserClaim(HttpContext);
                var res = await _service.GetWhere(_auth.CompanyId, ProjectId, Where);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        [HttpGet("{ProjectId}/{TaskId}")]
        public async Task<IActionResult> GetById(int ProjectId, int TaskId)
        {
            try
            {
                authenticationResponse _auth = securityService.UserClaim(HttpContext);
                var res = await _service.GetById(_auth.CompanyId, ProjectId, TaskId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(taskRequest entity)
        {
            try
            {
                authenticationResponse _auth = securityService.UserClaim(HttpContext);
                entity.CompanyId = _auth.CompanyId;
                entity.CreationUserId = _auth.UserId;
                var res = await _service.Add(entity);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(taskRequest entity)
        {
            try
            {
                authenticationResponse _auth = securityService.UserClaim(HttpContext);
                entity.CompanyId = _auth.CompanyId;
                entity.CreationUserId = _auth.UserId;
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
