using System;
using System.Collections.Generic;
using System.Text;

namespace DapperApp.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public string PrimaryKeyAttribute { get; set; }
        public string ForeignKeyAttribute { get; set; }

        public ColumnAttribute(string primaryKeyAttribute,string foreignKeyAttribute)
        {
            PrimaryKeyAttribute = primaryKeyAttribute;
            ForeignKeyAttribute = foreignKeyAttribute;
        }
    }
}
