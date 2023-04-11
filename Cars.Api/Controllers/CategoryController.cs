using Cars.Application.Commands.Categories;
using Cars.Application.Queries.Categories;
using Microsoft.AspNetCore.Mvc;
namespace Cars.Api.Controllers;

public class CategoryController : ApplicationController
{
    [HttpPost("/api/category/create/")]
    public async Task<OkObjectResult> CreateBrand(CreateCategoryCommand command) => Ok(await Mediator.Send(command));
    [HttpGet("/api/category/get/")]
    public async Task<OkObjectResult> CreateBrand(GetOneCategoryQuery query) => Ok(await Mediator.Send(query));
}
