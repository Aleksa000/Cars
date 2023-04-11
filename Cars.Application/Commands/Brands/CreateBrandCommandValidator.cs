using Cars.Application.Common.Validators.Brands;
using FluentValidation;

namespace Cars.Application.Commands.Brands;

public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(x => x.Brand)
            .SetValidator(new BrandDtoValidator());
    }
}