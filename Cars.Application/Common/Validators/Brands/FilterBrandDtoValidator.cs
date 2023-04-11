using Cars.Application.Common.Dtos.Brands;
using FluentValidation;

namespace Cars.Application.Common.Validators.Brands;

public class FilterBrandDtoValidator : AbstractValidator<FilterBrandDto>
{
    public FilterBrandDtoValidator()
    {
        RuleFor(x => x.Mark).MaximumLength(15);
        RuleFor(x => x.Model).MaximumLength(10);
    }
}