using AutoMapper;
using Cars.Application.Common.Dtos.Brands;
using Cars.Domain.Entities.Brands;
using Cars.Domain.Enums.Brands;
using MediatR;
using MongoDB.Entities;

namespace Cars.Application.Commands.Brands;

public record CreateBrandCommand(BrandDto Brand): IRequest<BrandDto>;

public class CreateBrandHandler: IRequestHandler<CreateBrandCommand,BrandDto>
{
    private readonly IMapper _mapper;

    public CreateBrandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<BrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = _mapper.Map<Brand>(request.Brand);
        
        brand.BrandTypes = BrandTypes.Automatic;
        
        await brand.SaveAsync(cancellation: cancellationToken);

        return request.Brand;

    }
}