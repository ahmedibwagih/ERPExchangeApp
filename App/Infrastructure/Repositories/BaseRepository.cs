using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Core.DTOs;
using Core.Repositories.Base;
using Dynamo.Core.Entities.Base;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly DBContext Context;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(DBContext context)
        {
            this.Context = context;
            DbSet = this.Context.Set<T>();
        }

        public virtual async Task<Tuple<ICollection<T>, int>> GetAllPagingAsync(PagingInputDto pagingInputDto)
        {
            IQueryable<T> query = GetQueryableForGetAllPaging();

            if (pagingInputDto.HiddenFilter != null)
            {
                query = query.Where(pagingInputDto.HiddenFilter);
            }

            if (pagingInputDto.Filter != null)
            {
                var props = typeof(T).GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(FilterAttribute)));
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

            return new Tuple<ICollection<T>, int>(await page.ToListAsync(), total);
        }

        public virtual IQueryable<T> GetQueryableForGetAllPaging()
        {
            return DbSet.AsQueryable();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }
        public virtual async Task<List<T>> GetAsync(string cond)
        {
            try
            {
                var query = DbSet.AsQueryable();
                query = query.Where(cond);
                return await query.ToListAsync();
            }
            catch (Exception ex)
            { 
            
            }
            return null;
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetByIdLightAsync(long id)
        {
            try
            {
                return await Context.Set<T>().FindAsync(id);
            }
            catch {  }

            return null;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<IList<T>> AddRangeAsync(IList<T> entity)
        {
            await DbSet.AddRangeAsync(entity);
            return entity;
        }

        public virtual void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }
    }
}
