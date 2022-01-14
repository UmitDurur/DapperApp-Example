using DapperApp.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        IConfiguration _configuration;
        private ICompanyRepository _companyRepository;
        private IBranchRepository _branchRepository;
        private IEmployeeRepository _employeeRepository;

        public UnitOfWork(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ICompanyRepository Companies => _companyRepository != null ? _companyRepository : new CompanyRepository(_configuration);

        public IBranchRepository Branches => _branchRepository!= null ?_branchRepository: new BranchRepository(_configuration);

        public IEmployeeRepository Employees => _employeeRepository != null ? _employeeRepository: new EmployeeRepository(_configuration);
    }
}
