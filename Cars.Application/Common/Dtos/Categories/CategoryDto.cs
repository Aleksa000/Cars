using Cars.Application.Common.Dtos.Brands;

namespace Cars.Application.Common.Dtos.Categories;

public record CategoryDto(string? CarBody, string? Fuel, string? MainBrandId, List<string> OtherBrandId);
