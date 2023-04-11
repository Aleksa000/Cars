using Cars.Domain.Entities.Categories;
using MongoDB.Entities;
namespace Cars.Domain.Entities.Capacities;

[Collection(name:"capacities")]
public class Capacity : Entity ,ICreatedOn, IModifiedOn
{
    [Field("cubic_capacity")]
    public string? CubicCapacity { get; set; }
    
    [Field("created_at")]
    public DateTime CreatedOn { get; set; }
    [Field("modified_at")]
    public DateTime ModifiedOn { get; set; }
    
     
   [InverseSide]
    public Many<Category> Categories { get; set; }

    public Capacity()
    {
        this.InitManyToMany(() => Categories,category=>category.Capacities);
    }
}