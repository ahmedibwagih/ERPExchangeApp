using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Core.DTOs;
using Core.Repositories.Auth;
using Dynamo.Core.Entities.Base;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRoleRepository : IUserRoleRepository<IdentityUserRole<string>>
    {
        protected readonly DBContext Context;
        private readonly DbSet<IdentityUserRole<string>> dbSet;

        public UserRoleRepository(DBContext context)
        {
            Context = context;
            dbSet = Context.Set<IdentityUserRole<string>>();
        }
        public virtual async Task<IdentityUserRole<string>> AddAsync(IdentityUserRole<string> entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<IList<IdentityUserRole<string>>> AddRangeAsync(IList<IdentityUserRole<string>> entity)
        {
            await dbSet.AddRangeAsync(entity);
            return entity;
        }

        public virtual async Task DeleteAsync(IdentityUserRole<string> entity)
        {
            dbSet.Remove(entity);
        }

        public virtual async Task DeleteAsync(IEnumerable<IdentityUserRole<string>> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public virtual async Task<Tuple<ICollection<IdentityUserRole<string>>, int>> GetAllAsync(PagingInputDto pagingInputDto)
        {
            var query = dbSet.AsQueryable();

            if (pagingInputDto.Filter != null)
            {
                var props = typeof(IdentityUserRole<string>).GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(FilterAttribute)));
                var condition = "";
                foreach (var p in props)
                {
                    condition = (condition == "" ? condition : condition + " || ") + p.Name + ".Contains(@0)";
                }

                query = query.Where(condition, pagingInputDto.Filter);
            }

            var order = query.OrderBy(pagingInputDto.OrderByField + " " + pagingInputDto.OrderType);

            var page = order.Skip(pagingInputDto.PageNumber * pagingInputDto.PageSize - pagingInputDto.PageSize).Take(pagingInputDto.PageSize);

            var total = await query.CountAsync();

            return new Tuple<ICollection<IdentityUserRole<string>>, int>(await page.ToListAsync(), total);
        }

        public virtual async Task<IdentityUserRole<string>> GetByIdAsync(long id)
        {
            return await Context.Set<IdentityUserRole<string>>().FindAsync(id);
        }

        public async Task<string[]> GetUserRoleIdsArrayAsync(string id)
        {
            return await dbSet.AsQueryable()
            .Where(x => x.UserId == id).Select(x => x.RoleId).ToArrayAsync();
        }
        public async Task<List<IdentityUserRole<string>>> GetUserRoleRemovedIdsByAsync(string id, string[] rolesIds)
        {
            return await dbSet.AsQueryable()
                .Where(x => x.UserId == id && !rolesIds.Contains(x.RoleId)).ToListAsync();
        }
    }
}
