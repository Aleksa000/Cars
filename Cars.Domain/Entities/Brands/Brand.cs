using Cars.Domain.Enums.Brands;
using MongoDB.Entities;

namespace Cars.Domain.Entities.Brands;
[Collection(name:"brands")]
public class Brand : Entity ,ICreatedOn, IModifiedOn
{
    [Field("mark")]
    public string? Mark { get; set; }
    
    [Field("model")]
    public string? Model { get; set; }
    
    [Field("brand_type")]
    public BrandTypes? BrandTypes { get; set; }
    
    [Field("about_car")]
    public string? AboutCar { get; set; }
    
    [Field("created_at")]
    public DateTime CreatedOn { get; set; }
    [Field("modified_at")]
    public DateTime ModifiedOn { get; set; }
    
}
