namespace Cars.Application.Common.Dtos;

public class PaginationData<TDto>
{
    public List<TDto> Results { get; set; }
    public long TotalPages { get; set; }
    public long TotalRows { get; set; }
    public int PageIndex { get; set; }
    public int RowsNumber { get; set; }
}