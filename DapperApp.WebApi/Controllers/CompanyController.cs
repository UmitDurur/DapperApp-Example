using DapperApp.Application.Interfaces;
using DapperApp.Core.Entities;
using DapperApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetAllAsync()
        {
            var companies = await unitOfWork.Companies.GetAllAsync();
            return Ok(companies);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Company>>> GetAllJoinAsync()
        {
            var companies = await unitOfWork.Companies.GetAllJoinAsync();
            return Ok(companies);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Company>> GetById(int id)
        {
            var companies = await unitOfWork.Companies.GetByIdAsync(id);
            return Ok(companies);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddAsync([FromBody] Company company)
        {
            var result = await unitOfWork.Companies.AddAsync(company);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateAsync([FromBody] Company company)
        {
            var result = await unitOfWork.Companies.UpdateAsync(company);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteAsync(int id)
        {
            var result = await unitOfWork.Companies.DeleteAsync(id);
            return Ok(result);
        }
    }
}
