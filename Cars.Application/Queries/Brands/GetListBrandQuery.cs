using AutoMapper;
using Cars.Application.Common.Dtos;
using Cars.Application.Common.Dtos.Brands;
using Cars.Application.Common.Dtos.Categories;
using Cars.Application.Extensions;
using Cars.Domain.Entities.Brands;
using Cars.Domain.Entities.Categories;
using MediatR;
using MongoDB.Driver;
using MongoDB.Entities;

namespace Cars.Application.Queries.Brands;

public record GetListBrandQuery(int PageIndex, int RowsNumber, FilterBrandDto? Filter) : IRequest<PaginationData<BrandDto>> ;

public class GetOneBrandHandler : IRequestHandler<GetListBrandQuery, PaginationData<BrandDto>>
{

    private readonly IMapper _mapper;

    public GetOneBrandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<PaginationData<BrandDto>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
    {
        var paginationResult = await DB.PagedSearch<Brand>()
            .Match(new FilterDefinitionBuilder<Brand>().Empty.ApplyFilter(request.Filter))
            .PageNumber(request.PageIndex)
            .PageSize(request.RowsNumber)
            .Sort(x=>x.Descending(y=>y.CreatedOn)).ExecuteAsync(cancellationToken);


        var paginationResponse = new PaginationData<BrandDto>
        {
            Results = new List<BrandDto>(paginationResult.Results.Select(x => _mapper.Map<BrandDto>(x))),
            PageIndex = request.PageIndex,
            TotalPages = paginationResult.PageCount,
            RowsNumber = request.RowsNumber,
            TotalRows = paginationResult.TotalCount
        };
      
        return paginationResponse ;
    }
}