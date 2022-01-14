using System;
using System.Collections.Generic;
using System.Text;

namespace DapperApp.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {

        public string TableName { get; set; }
        public string PrimaryKeyAttribute { get; set; }
        public string ForeignKeyAttribute { get; set; }

        public ColumnAttribute(string tableName,string primaryKeyAttribute,string foreignKeyAttribute)
        {
            TableName = tableName;
            PrimaryKeyAttribute = primaryKeyAttribute;
            ForeignKeyAttribute = foreignKeyAttribute;
        }
    }
}
