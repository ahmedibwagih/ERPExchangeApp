using Core.DTOs;

namespace Application.Core.Services
{
    //public interface IService<TEntity, TDto, TUpdateDto, TGetAllDto>
    //where TEntity : class
    //where TDto : class
    //where TUpdateDto : class
    //where TGetAllDto : class
    //{
    //    Task<PagingResultDto<TGetAllDto>> GetAllPaging(PagingInputDto pagingInputDto);
    //    Task<TDto> GetById(long id);
    //    Task Delete(long id);
    //    Task<TDto> Create(TDto input);
    //    Task<TDto> Update(TUpdateDto input);
    //    Task<IList<TGetAllDto>> GetAll();
    //}

    public interface IService<TEntity, TDto, TCreateDto, TUpdateDto, TGetAllDto>
        where TEntity : class
        where TDto : class
        where TCreateDto : class
        where TUpdateDto : class
        where TGetAllDto : class
    {
        Task<PagingResultDto<TGetAllDto>> GetAllPaging(PagingInputDto pagingInputDto);
        Task<TDto> GetById(long id);
        Task Delete(long id);
        Task<TDto> Create(TCreateDto input);
        Task<TDto> Update(TUpdateDto input);
        Task<IList<TGetAllDto>> GetAll();
        Task<List<TDto>> GetByCond(string cond);
    }
}
