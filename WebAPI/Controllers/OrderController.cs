using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly ILogger<OrderController> _logger;

    public OrderController(IOrderService orderService, ILogger<OrderController> logger)
    {
        _orderService = orderService;
        _logger = logger;
    }
    
    [HttpGet(Name = "SaveOrders")]
    public async Task Save()
    {
        await _orderService.SaveAllOrdersToFileAsync();
    }
}