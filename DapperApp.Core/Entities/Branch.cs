using DapperApp.Core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DapperApp.Core.Entities
{
    [Table(TableName = "Branches")]
    public class Branch
    {
        [Description("ignore")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public int CompanyId { get; set; }
        [Column("Companies","CompanyId","Id")]
        public Company Company { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
