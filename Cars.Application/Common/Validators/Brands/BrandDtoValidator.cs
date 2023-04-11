using Cars.Application.Common.Dtos.Brands;
using FluentValidation;

namespace Cars.Application.Common.Validators.Brands;

public class BrandDtoValidator : AbstractValidator<BrandDto>
{
    public BrandDtoValidator()
    {
        RuleFor(x => x.Mark).MaximumLength(15).NotEmpty();
        //RuleFor(x => x.Email).EmailAddress().MaximumLength(512).NotEmpty().WithMessage();
        RuleFor(x => x.Model).MaximumLength(10).NotEmpty();
    }
}