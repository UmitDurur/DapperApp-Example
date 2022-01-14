using System;
using System.Collections.Generic;
using System.Text;

namespace DapperApp.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        public string TableName { get; set; }
    }
}
