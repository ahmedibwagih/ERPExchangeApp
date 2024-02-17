using System.Collections.Generic;

namespace Core.DTOs;

public class PagingResultDto<TEntity>
{
    public int Total { get; set; }

    public IList<TEntity> Result { get; set; }

}