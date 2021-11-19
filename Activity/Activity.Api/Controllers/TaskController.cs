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
    public class TaskController : ControllerBase
    {
        private readonly IService3<taskRequest, taskResponse> _service;
        public TaskController(IService3<taskRequest, taskResponse> service)
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
        [HttpGet("{CompanyId}/{ProjectId}/Where={Where}")]
        public async Task<IActionResult> GetWhere(int CompanyId, int ProjectId, string Where)
        {
            try
            {
                var res = await _service.GetWhere(CompanyId, ProjectId, Where);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        [HttpGet("{CompanyId}/{ProjectId}/{SprintId}/{TaskId}")]
        public async Task<IActionResult> GetById(int CompanyId,int ProjectId, int TaskId)
        {
            try
            {
                var res = await _service.GetById(CompanyId, ProjectId, TaskId);
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
