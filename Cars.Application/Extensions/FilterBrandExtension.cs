using Cars.Application.Common.Dtos.Brands;
using Cars.Domain.Entities.Brands;
using MongoDB.Driver;

namespace Cars.Application.Extensions;

public static class FilterBrandExtension
{
   public static FilterDefinition<Brand> ApplyFilter(this FilterDefinition<Brand> filter,
      FilterBrandDto? filterDto)
   {
      if (filterDto is not { }) return filter;


      if (!string.IsNullOrEmpty(filterDto.Mark))
      {
         filter &= new FilterDefinitionBuilder<Brand>().And(
            new FilterDefinitionBuilder<Brand>().Where(x=>x.Mark != null),
            new FilterDefinitionBuilder<Brand>().Where(x=>x.Mark!.Contains(filterDto.Mark))
            );

      }
      if (!string.IsNullOrEmpty(filterDto.Model))
      {
         filter &= new FilterDefinitionBuilder<Brand>().And(
            new FilterDefinitionBuilder<Brand>().Where(x=>x.Model != null),
            new FilterDefinitionBuilder<Brand>().Where(x=>x.Model!.Contains(filterDto.Model))
         );

      }

      return filter;
   }
}