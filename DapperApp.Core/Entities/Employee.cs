using DapperApp.Core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DapperApp.Core.Entities
{
    [Table(TableName ="Employees")]
    public class Employee
    {
        [Description("ignore")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
