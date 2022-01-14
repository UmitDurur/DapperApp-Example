using DapperApp.Application.Interfaces;
using DapperApp.Core.Entities;
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
    public class BranchController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        public BranchController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branch>>> GetAllAsync()
        {
            var branches = await unitOfWork.Branches.GetAllAsync();
            return Ok(branches);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Branch>>> GetAllJoinAsync()
        {
            var branches = await unitOfWork.Branches.GetAllJoinAsync();
            return Ok(branches);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Branch>> GetById(int id)
        {
            var branch = await unitOfWork.Branches.GetByIdAsync(id);
            return Ok(branch);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddAsync([FromBody] Branch branch)
        {
            var result = await unitOfWork.Branches.AddAsync(branch);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateAsync([FromBody] Branch branch)
        {
            var result = await unitOfWork.Branches.UpdateAsync(branch);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteAsync(int id)
        {
            var result = await unitOfWork.Branches.DeleteAsync(id);
            return Ok(result);
        }
    }
}
