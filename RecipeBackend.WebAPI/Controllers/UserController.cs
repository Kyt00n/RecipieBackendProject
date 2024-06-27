using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeBackend.Application.Interfaces;
using RecipeBackend.Domain.Entities;

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
    private readonly IUserRepository _userRepository;
    private readonly TokenService _tokenService;

    public UserController(IUserRepository userRepository, TokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserDto userDto)
    {
        var existingUser = await _userRepository.GetUserByUsername(userDto.Username);
        if (existingUser != null)
            return BadRequest("Username already taken");

        var user = new UserEntity
        {
            Username = userDto.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
            Email = userDto.Email,
            Role = userDto.Role
        };

        await _userRepository.AddUser(user);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var user = await _userRepository.GetUserByUsername(loginDto.Username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            return Unauthorized();

        var token = _tokenService.GenerateToken(user);
        return Ok(new { Token = token });
    }

    [HttpPost]
    public IActionResult Login()
    {
        return Ok();
    }
}