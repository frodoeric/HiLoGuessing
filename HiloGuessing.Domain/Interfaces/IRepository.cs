using HiloGuessing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiLoGuessing.Infrastructure;

namespace HiloGuessing.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T id);
        Task DeleteAsync(T entity);
    }

}
