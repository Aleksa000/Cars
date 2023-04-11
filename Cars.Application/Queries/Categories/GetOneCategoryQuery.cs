using AutoMapper;
using Cars.Application.Common.Dtos.Brands;
using Cars.Application.Common.Dtos.Categories;
using Cars.Domain.Entities.Brands;
using Cars.Domain.Entities.Categories;
using MediatR;
using MongoDB.Driver;
using MongoDB.Entities;

namespace Cars.Application.Queries.Categories;

public record GetOneCategoryQuery(string? Id) : IRequest<GetCagetoryDto> ;

public class GetOneCategoryHandler : IRequestHandler<GetOneCategoryQuery, GetCagetoryDto>
{

    private readonly IMapper _mapper;

    public GetOneCategoryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<GetCagetoryDto> Handle(GetOneCategoryQuery request, CancellationToken cancellationToken)
    {
        var category =  await DB.Find<Category>()
            .OneAsync(request.Id, cancellationToken);

        var categoryDto = new GetCagetoryDto(category.CarBody,category.Fuel, _mapper.Map<BrandDto>(await category.MainBrandId.ToEntityAsync(cancellation: cancellationToken)),
            new List<BrandDto>((await category.OtherBrandIds.ChildrenFluent().ToListAsync(cancellationToken: cancellationToken)).Select(x=> _mapper.Map<BrandDto>(x)))
            );
      
        return categoryDto;
    }
}