using AutoMapper;
using Emporium.API.Models.Requests;
using Emporium.Application.DTO;
using Emporium.Application.Service;
using Emporium.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Emporium.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(ProductService service, IMapper mapper) : ControllerBase
{
    private readonly ProductService _service = service;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<IEnumerable<ProductDto>> Get()
    {
        var products = await _service.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> Get(Guid id)
    {
        var product = await _service.GetByIdAsync(id);
        if (product is null) return NotFound();
        return _mapper.Map<ProductDto>(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Post([FromBody] CreateProductRequest request)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            Description = request.Description,
            StockQuantity = 0,
            Category = new Category { Name = string.Empty },
            CategoryId = Guid.Empty
        };
        var created = await _service.CreateAsync(product);
        var dto = _mapper.Map<ProductDto>(created);
        return CreatedAtAction(nameof(Get), new { id = dto.ProductId }, dto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
