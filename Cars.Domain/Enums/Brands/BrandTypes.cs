using Ardalis.SmartEnum;
namespace Cars.Domain.Enums.Brands;

public class BrandTypes : SmartEnum<BrandTypes>
{
    public static readonly BrandTypes Automatic = new(nameof(Automatic), 1);
    public static readonly BrandTypes Manual = new(nameof(Manual), 2);
    
    public BrandTypes(string name, int value) : base(name, value)
    {
    }
}