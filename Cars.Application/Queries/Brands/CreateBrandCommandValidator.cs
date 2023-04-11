using Cars.Application.Commands.Brands;
using Cars.Application.Common.Validators.Brands;
using FluentValidation;

namespace Cars.Application.Queries.Brands;

public class GetListBrandQueryValidator : AbstractValidator<GetListBrandQuery>
{
    public GetListBrandQueryValidator()
    {
        RuleFor(x => x.PageIndex)
            .GreaterThan(0);
        RuleFor(x => x.RowsNumber)
            .GreaterThan(0);
        RuleFor(x => x.Filter)
            .SetValidator(new FilterBrandDtoValidator());
    }
}