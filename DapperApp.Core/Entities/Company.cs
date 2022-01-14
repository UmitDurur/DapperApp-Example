using DapperApp.Core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DapperApp.Core.Entities
{
    [Table(TableName = "Companies")]
    public class Company
    {
        [Description("ignore")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column("Id","CompanyId")]
        public ICollection<Branch> Branches { get; set; }
    }
}
