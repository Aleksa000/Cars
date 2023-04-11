using Cars.Application.Common.Dtos.Brands;

namespace Cars.Application.Common.Dtos.Categories;

public record GetCagetoryDto(string? CarBody, string? Fuel, BrandDto? MainBrand, List<BrandDto>? OtherBrand );
