using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Api.Controllers;

public class ApplicationController : ControllerBase
{
    private ISender _sender;

    protected ISender Mediator => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}