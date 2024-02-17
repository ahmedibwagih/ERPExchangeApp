namespace Core.DTOs
{
    public class PagingInputDto
    {
        private int pageNumber;
        private int pageSize;
        private string orderByField;
        private string orderType;

        public int PageNumber { get => pageNumber == 0 ? 1 : pageNumber; set => pageNumber = value; }
        public int PageSize { get => pageSize == 0 ? 10 : pageSize; set => pageSize = value; }
        public string OrderByField { get => string.IsNullOrEmpty(orderByField) ? "Id" : orderByField; set => orderByField = value; }
        public string OrderType { get => string.IsNullOrEmpty(orderType) ? "asc" : orderType; set => orderType = value; }
        public string Filter { get; set; }
        public string HiddenFilter { get; set; }
    }
}

