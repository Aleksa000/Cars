using AutoMapper;
using Cars.Application.Common.Dtos.Categories;
using Cars.Domain.Entities.Capacities;
using Cars.Domain.Entities.Categories;
using MediatR;
using MongoDB.Entities;

namespace Cars.Application.Commands.Categories;

public record CreateCategoryCommand(CategoryDto Category): IRequest<CategoryDto>;

public class CreateCategoryHandler: IRequestHandler<CreateCategoryCommand,CategoryDto>
{
    private readonly IMapper _mapper;

    public CreateCategoryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request.Category);

        var capacity = new Capacity
        {
            CubicCapacity="1.9 TDI"
        };

        await capacity.SaveAsync(cancellation: cancellationToken);
        
        await category.SaveAsync(cancellation: cancellationToken);
        
        await category.Capacities.AddAsync(capacity, cancellation: cancellationToken);
        await category.OtherBrandIds.AddAsync(request.Category.OtherBrandId, cancellation: cancellationToken);
        
        return request.Category;

    }
}