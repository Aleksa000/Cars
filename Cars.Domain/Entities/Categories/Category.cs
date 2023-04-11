using Cars.Domain.Entities.Brands;
using Cars.Domain.Entities.Capacities;
using MongoDB.Entities;

namespace Cars.Domain.Entities.Categories;

public class Category : Entity ,ICreatedOn, IModifiedOn
{
    [Field("car_body")]
    public string? CarBody { get; set; }
    
    [Field("fuel")]
    public string?  Fuel { get; set; }
    
    [Field("main_brand_id")]
    public One<Brand> MainBrandId { get; set; }
    
    [Field("other_brand_ids")]
    public Many<Brand> OtherBrandIds { get; set; }
    
    [Field("created_at")]
    public DateTime CreatedOn { get; set; }
    [Field("modified_at")]
    public DateTime ModifiedOn { get; set; }
    
    [OwnerSide]
    public Many<Capacity> Capacities { get; set; }

    public Category()
    {
        this.InitOneToMany(() => OtherBrandIds);
        this.InitManyToMany(() => Capacities,capacity=>capacity.Categories);
     
    }

}