using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DTOs;

namespace Core.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<Tuple<ICollection<T>, int>> GetAllPagingAsync(PagingInputDto pagingInputDto);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAsync(string cond);
        Task<T> GetByIdAsync(long id);
        Task<T> GetByIdLightAsync(long id);
        Task<T> AddAsync(T entity);
        Task<IList<T>> AddRangeAsync(IList<T> entity);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
    }
}
