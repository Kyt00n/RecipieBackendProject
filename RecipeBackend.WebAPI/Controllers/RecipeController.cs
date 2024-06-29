using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeBackend.Application.Features.RecipeFeatures.Commands;
using RecipeBackend.Application.Features.RecipeFeatures.Queries;

namespace RecipeBackend.WebAPI.Controllers;


[Route("api/[controller]")]
// [Authorize]
[ApiController]
public class RecipeController : ControllerBase
{
    private readonly IMediator _mediator;

    public RecipeController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateRecipeCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetRecipiesByUserId(int userId)
    {
        return Ok(await _mediator.Send(new GetRecipeIdsByProductsQuery() { UserId = userId }));
    }
    
}
