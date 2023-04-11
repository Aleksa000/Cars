using AutoMapper;
using Cars.Application.Common.Dtos.Categories;
using Cars.Domain.Entities.Categories;

namespace Cars.Application.MappingProfiles.Categories;

public class MappingProfile : Profile

{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
    
}