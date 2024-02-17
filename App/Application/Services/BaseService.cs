using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Core.Services;
using Core.DTOs;
using Core.Other;
using Core.Repositories.Base;
using Core.UnitOfWork;
using Dynamo.Core.Entities.Base;
using Dynamo.Core.Other;

namespace Application.Services
{
    public class BaseService<TEntity, TDto, TCreateDto, TUpdateDto, TGetAllDto> : IService<TEntity, TDto, TCreateDto, TUpdateDto, TGetAllDto>
        where TEntity : class
        where TDto : EntityDto
        where TCreateDto : EntityDto
        where TUpdateDto : EntityDto
        where TGetAllDto : class
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IRepository<TEntity> Repository;

        public BaseService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            Repository = (IRepository<TEntity>)this.UnitOfWork.GetRepositoryByName(typeof(TEntity).Name);

        }

        public virtual async Task<PagingResultDto<TGetAllDto>> GetAllPaging(PagingInputDto pagingInputDto)
        {
            var result = await Repository.GetAllPagingAsync(pagingInputDto);

            var list = Mapper.MapperObject.Mapper.Map<IList<TGetAllDto>>(result.Item1);

            var response = new PagingResultDto<TGetAllDto>
            {
                Result = list,
                Total = result.Item2
            };

            return response;
        }

        public virtual async Task<IList<TGetAllDto>> GetAll()
        {
            var list = await Repository.GetAllAsync();
            var result = Mapper.MapperObject.Mapper.Map<IList<TGetAllDto>>(list);

            return result;
        }

        public virtual async Task<List<TDto>> GetByCond(string cond)
        {
            var entity = await Repository.GetAsync(cond);

            var response = Mapper.MapperObject.Mapper.Map<List<TDto>>(entity);

            return response;
        }


        public virtual async Task<TDto> GetById(long id)
        {
            var entity = await Repository.GetByIdAsync(id);

            var response = Mapper.MapperObject.Mapper.Map<TDto>(entity);

            return response;
        }

        public virtual async Task Delete(long id)
        {
            var entity = await Repository.GetByIdAsync(id);

            if (entity == null)
                throw new DynamoException(AppMessages.RecordNotExisted);

            var isSoftDelete = typeof(TEntity).GetInterfaces().Any(x => x == typeof(ISoftDelete));

            if (isSoftDelete)
            {
                ((ISoftDelete)entity).IsDeleted = true;
            }
            else
            {
                Repository.Delete(entity);
            }

            await UnitOfWork.CompleteAsync();
        }

        public virtual async Task<TDto> Create(TCreateDto input)
        {


            try
            {
                var entity = Mapper.MapperObject.Mapper.Map<TEntity>(input);
                if (entity is null)
                {
                    throw new DynamoException(AppMessages.InternalError);
                }

                await OnCreating(entity, input);

            
                UnitOfWork.BeginTran();

                var newEntity = await Repository.AddAsync(entity);

                await UnitOfWork.CompleteAsync();

                await OnCreated(newEntity, input);

                UnitOfWork.CommitTran();

                var response = Mapper.MapperObject.Mapper.Map<TDto>(newEntity);
                return response;
            }
            catch (System.Exception ex)
            {

                throw;
            }
            return null;
        }



        public virtual async Task<TDto> Update(TUpdateDto input)
        {
            var entity = await Repository.GetByIdAsync(input.Id);

            if (entity == null)
                throw new DynamoException(AppMessages.RecordNotExisted);

            UnitOfWork.BeginTran();

            Mapper.MapperObject.Mapper.Map(input, entity, typeof(TDto), typeof(TEntity));

            await OnUpdating(entity, input);

            await UnitOfWork.CompleteAsync();

            await OnUpdated(entity, input);

            UnitOfWork.CommitTran();

            var response = Mapper.MapperObject.Mapper.Map<TDto>(entity);

            return response;
        }

        protected async virtual Task<bool> OnCreating(TEntity entity, TCreateDto dto)
        {
            return true;

        }

     

        protected async virtual Task<bool> OnUpdating(TEntity entity, TUpdateDto dto)
        {
            return true;
        }

        protected async virtual Task<bool> OnCreated(TEntity entity, TCreateDto dto)
        {
            return true;
        }

      

        protected async virtual Task<bool> OnUpdated(TEntity entity, TUpdateDto dto)
        {
            return true;
        }
    }
}
