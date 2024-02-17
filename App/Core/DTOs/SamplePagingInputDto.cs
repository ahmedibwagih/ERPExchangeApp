using Core.Other;

namespace Core.DTOs
{
    public class SamplePagingInputDto
    {
        private int pageNumber;
        private int pageSize;

        public int PageNumber { get => pageNumber == 0 ? 1 : pageNumber; set => pageNumber = value; }
        public int PageSize { get => pageSize == 0 ? 10 : pageSize; set => pageSize = value; }


    }
}

