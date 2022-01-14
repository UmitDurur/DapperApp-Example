using System;
using System.Collections.Generic;
using System.Text;

namespace DapperApp.Application.Interfaces
{
    public interface IUnitOfWork
    {
        ICompanyRepository Companies { get; }
        IBranchRepository Branches { get; }
        IEmployeeRepository Employees { get; }
    }
}
