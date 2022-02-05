using PayNext.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayNext.Core.Interfaces
{
  public interface IAsyncRepository<T> where T : BaseEntity, IAggregateRoot
  {
    Task<T> GetByIdAsync(int id);
    Task<T> GetByIdAsync(ISpecification<T> spec);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task<int> DeleteAsync(T entity);
    Task<int> CountAsync(ISpecification<T> spec);
  }
}
