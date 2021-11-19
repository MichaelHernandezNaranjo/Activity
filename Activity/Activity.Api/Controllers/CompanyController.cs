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
    public class CompanyController : ControllerBase
    {
        private readonly IService<companyRequest, companyResponse> _service;
        public CompanyController(IService<companyRequest, companyResponse> service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var res = await _service.GetAll();
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        [HttpGet("{CompanyId}")]
        public async Task<IActionResult> GetById(int CompanyId)
        {
            try
            {
                var res = await _service.GetById(CompanyId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(companyRequest entity)
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


    }
}
