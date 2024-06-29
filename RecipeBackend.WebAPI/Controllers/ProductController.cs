using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeBackend.Application.Features.ProductFeatures.Commands;

namespace RecipeBackend.WebAPI.Controllers;
[ApiController]
// [Authorize]
[Route("api/product")]
public class ProductController : ControllerBase
{
    private  IMediator? _mediator;
    private IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}