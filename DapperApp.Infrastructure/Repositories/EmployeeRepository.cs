using DapperApp.Application.Interfaces;
using DapperApp.Core.Attributes;
using DapperApp.Core.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DapperApp.Infrastructure.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly IConfiguration configuration;
        private readonly string tableName;

        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
            this.tableName = ((TableAttribute)Attribute.GetCustomAttribute(typeof(Employee), typeof(TableAttribute))).TableName;
        }
    }
}
