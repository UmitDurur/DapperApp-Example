using Dapper;
using DapperApp.Application.Interfaces;
using DapperApp.Core.Attributes;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DapperApp.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IConfiguration configuration;
        private readonly string _tableName;

        public GenericRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            _tableName = ((TableAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(TableAttribute))).TableName;
        }

        private SqlConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return connection;
        }

        public async Task<int> AddAsync(T entity)
        {
            var query = GenerateInsertQuery();
            using var connection = CreateConnection();

            var result = await connection.ExecuteAsync(query, entity);
            return result;
            //throw new NotImplementedException();
        }

        private string GenerateInsertQuery()
        {
            var insertQuery = new StringBuilder($"INSERT INTO {_tableName}");
            insertQuery.Append("(");

            var properties = GenerateListOfProperties(GetProperties);
            properties.ForEach(prop => { insertQuery.Append($"[{prop}],"); });

            insertQuery.
                Remove(insertQuery.Length - 1, 1).
                Append(") VALUES(");
            properties.ForEach(prop => { insertQuery.Append($"@{prop},"); });


            insertQuery.
                Remove(insertQuery.Length - 1, 1).
                Append(")");

            return insertQuery.ToString();
        }



        public async Task<int> DeleteAsync(int id)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync($"DELETE FROM {_tableName} WHERE Id=@Id", new { Id = id });
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<T>($"SELECT * FROM {_tableName}");
        }

        public async Task<IEnumerable<T>> GetAllJoinAsync()
        {
            StringBuilder query = new StringBuilder("SELECT * FROM Companies");
            var propList = (from prop in GetProperties
                            let attributes = prop.GetCustomAttributes(typeof(ColumnAttribute), false)
                            where attributes.Length >0 && (attributes[0] as ColumnAttribute)?.PrimaryKeyAttribute != null && (attributes[0] as ColumnAttribute)?.ForeignKeyAttribute != null
                            select prop.Name).ToList();

            return null;
        }



        public async Task<T> GetByIdAsync(int id)
        {
            using var connection = CreateConnection();
            var result = await connection.QuerySingleOrDefaultAsync<T>($"SELECT * FROM {_tableName} WHERE Id=@Id", new { Id = id });
            if (result == null)
                throw new KeyNotFoundException($"{_tableName} with id [{id}] could not be found.");
            return result;
        }

        public async Task<int> UpdateAsync(T entity)
        {
            var query = GenerateUpdateQuery();
            using var connection = CreateConnection();

            var result = await connection.ExecuteAsync(query, entity);
            return result;
        }

        private string GenerateUpdateQuery()
        {
            var updateQuery = new StringBuilder($"UPDATE {_tableName} SET ");

            var properties = GenerateListOfProperties(GetProperties);

            properties.ForEach(prop =>
            {
                if (!prop.Equals("Id"))
                {
                    updateQuery.Append($"{prop}=@{prop},");
                }
            });
            updateQuery.Remove(updateQuery.Length - 1, 1);
            updateQuery.Append(" WHERE Id=@Id");

            return updateQuery.ToString();
        }

        private IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();

        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    select prop.Name).ToList();
        }
    }
}
