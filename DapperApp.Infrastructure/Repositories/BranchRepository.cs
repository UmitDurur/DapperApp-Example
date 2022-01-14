using Dapper;
using DapperApp.Application.Interfaces;
using DapperApp.Core.Attributes;
using DapperApp.Core.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperApp.Infrastructure.Repositories
{
    public class BranchRepository : GenericRepository<Branch>,IBranchRepository
    {
        private readonly IConfiguration configuration;
        private readonly string tableName;

        public BranchRepository(IConfiguration configuration): base(configuration)
        {
            this.configuration = configuration;
            this.tableName =((TableAttribute)Attribute.GetCustomAttribute(typeof(Branch), typeof(TableAttribute))).TableName;
        }
    }
}
