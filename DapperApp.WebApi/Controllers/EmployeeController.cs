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
    public class EmployeeController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllAsync()
        {
            var employees = await unitOfWork.Employees.GetAllAsync();
            return Ok(employees);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var employee = await unitOfWork.Employees.GetByIdAsync(id);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddAsync([FromBody] Employee employee)
        {
            var result = await unitOfWork.Employees.AddAsync(employee);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateAsync([FromBody] Employee employee)
        {
            var result = await unitOfWork.Employees.UpdateAsync(employee);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteAsync(int id)
        {
            var result = await unitOfWork.Employees.DeleteAsync(id);
            return Ok(result);
        }
    }
}
