using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DTOs;

namespace Core.Repositories.Auth
{
    public interface IUserRoleRepository<T> where T : class
    {
        Task<Tuple<ICollection<T>, int>> GetAllAsync(PagingInputDto pagingInputDto);
        Task<T> GetByIdAsync(long id);
        Task<T> AddAsync(T entity);
        Task<IList<T>> AddRangeAsync(IList<T> entity);
        Task DeleteAsync(T entity);
        Task DeleteAsync(IEnumerable<T> entities);
        Task<string[]> GetUserRoleIdsArrayAsync(string id);
        Task<List<T>> GetUserRoleRemovedIdsByAsync(string id, string[] rolesIds);
    }
}
