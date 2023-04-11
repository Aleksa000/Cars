using AutoMapper;
using Cars.Application.Common.Dtos.Brands;
using Cars.Domain.Entities.Brands;

namespace Cars.Application.MappingProfiles.Brands;

public class MappingProfile : Profile

{
    public MappingProfile()
    {
        CreateMap<BrandDto, Brand>().ForMember(x => x.AboutCar, opt => opt.MapFrom(src => src.Mark + " " + src.Model));
        CreateMap<Brand, BrandDto>();
    }
    
}