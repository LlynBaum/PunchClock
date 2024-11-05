using M223PunchclockDotnet.Dto;
using M223PunchclockDotnet.Model;
using M223PunchclockDotnet.Service;
using Microsoft.AspNetCore.Mvc;

namespace M223PunchclockDotnet.Controllers;

[ApiController]
[Route("tag")]
public class CategoryController(CategoryService service) : Controller
{
    [HttpGet]
    public async Task<ActionResult<List<Category>>> GetAll(CancellationToken cancellationToken)
    {
        var categories = await service.GetAllAsync(cancellationToken);
        return Ok(categories);
    }

    [HttpGet("/{id:int}")]
    public async Task<ActionResult<Category>> Get(int id, CancellationToken cancellationToken)
    {
        try
        {
            var category = await service.GetByIdAsync(id, cancellationToken);
            return Ok(category); 
        }
        catch (ArgumentException)
        {
            return NotFound($"Can not find a Category with Id = {id}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Category>> Create([FromBody] CategoryDto categoryDto, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Title = categoryDto.Title
        };

        await service.CreateAsync(category, cancellationToken);
        return Ok(category);
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<Category>> Update(int id, [FromBody] CategoryDto categoryDto, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Title = categoryDto.Title
        };

        await service.UpdateAsync(id, category, cancellationToken);
        return Ok(category);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Category>> Delete(int id, CancellationToken cancellationToken)
    {
        try
        {
            var category = await service.DeleteAsync(id, cancellationToken);
            return category;
        }
        catch (ArgumentException)
        {
            return NotFound($"Can not find Category with Id {id}");
        }
    }
}