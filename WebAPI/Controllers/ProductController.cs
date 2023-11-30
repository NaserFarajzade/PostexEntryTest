using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly ILogger<ProductController> _logger;

    public ProductController(IProductService productService, ILogger<ProductController> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    [HttpGet(Name = "SaveProducts")]
    public async Task Save()
    {
        await _productService.SaveAllProductsToFileAsync();
    }
}