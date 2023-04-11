using Cars.Application.Commands.Brands;
using Cars.Application.Queries.Brands;
using Microsoft.AspNetCore.Mvc;
namespace Cars.Api.Controllers;

public class BrandController : ApplicationController
{
    [HttpPost("/api/brand/create/")]
    public async Task<OkObjectResult> CreateBrand(CreateBrandCommand command) => Ok(await Mediator.Send(command));
    
    [HttpGet("/api/brand/list/")]
    public async Task<OkObjectResult> GetBrand(GetListBrandQuery query) => Ok(await Mediator.Send(query));

}
