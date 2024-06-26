using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace RecipeBackend.WebAPI.Controllers;

[ApiController]
[Route("api/login")]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;

    public UserController(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    [HttpPost]
    public IActionResult Login()
    {
        return Ok();
    }
}