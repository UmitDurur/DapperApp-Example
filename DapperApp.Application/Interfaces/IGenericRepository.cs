using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DapperApp.Core.Entities;

namespace DapperApp.Application.Interfaces
{
    public interface IGenericRepository<T> where T:class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllJoinAsync();
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(int id);
    }
}
