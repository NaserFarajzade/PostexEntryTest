using Microsoft.AspNetCore.Mvc;
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

    [HttpGet(Name = "SaveUsers")]
    public async Task Save()
    {
        await _userService.SaveAllUsersToFileAsync();
    }
}