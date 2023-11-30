using Microsoft.AspNetCore.Mvc;
using Models.OnlineShop;
using Services.Abstraction;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;
    
    public UserController(IUserService userService,ILogger<UserController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpGet(Name = "GetUsers")]
    public async Task<IActionResult> Get()
    {
        var result = await _userService.GetAllUsersAsync();
        return Ok(result);
    }
}