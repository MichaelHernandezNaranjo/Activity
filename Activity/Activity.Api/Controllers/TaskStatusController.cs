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
    public class TaskStatusController : ControllerBase
    {
        private readonly IService3<taskStatusRequest, taskStatusResponse> _service;
        public TaskStatusController(IService3<taskStatusRequest, taskStatusResponse> service)
        {
            _service = service;
        }
        [HttpGet("{CompanyId}/{ProjectId}")]
        public async Task<IActionResult> GetAll(int CompanyId, int ProjectId)
        {
            try
            {
                var res = await _service.GetAll(CompanyId, ProjectId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        [HttpGet("{CompanyId}/{ProjectId}/{TaskStatusId}")]
        public async Task<IActionResult> GetById(int CompanyId,int ProjectId, int TaskStatusId)
        {
            try
            {
                var res = await _service.GetById(CompanyId, ProjectId, TaskStatusId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(taskStatusRequest entity)
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
        public async Task<IActionResult> Update(taskStatusRequest entity)
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
