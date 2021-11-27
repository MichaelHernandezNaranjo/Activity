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
    public class ProjectController : ControllerBase
    {
        private readonly IService2<projectRequest, projectResponse> _service;
        public ProjectController(IService2<projectRequest, projectResponse> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                authenticationResponse _auth = securityService.UserClaim(HttpContext);
                var res = await _service.GetAll(_auth.CompanyId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        [HttpGet("{ProjectId}")]
        public async Task<IActionResult> GetById(int ProjectId)
        {
            try
            {
                authenticationResponse _auth = securityService.UserClaim(HttpContext);
                var res = await _service.GetById(_auth.CompanyId, ProjectId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(projectRequest entity)
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
        public async Task<IActionResult> Update(projectRequest entity)
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
