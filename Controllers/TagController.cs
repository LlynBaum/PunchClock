using M223PunchclockDotnet.Dto;
using M223PunchclockDotnet.Model;
using M223PunchclockDotnet.Service;
using Microsoft.AspNetCore.Mvc;

namespace M223PunchclockDotnet.Controllers;

[ApiController]
[Route("tag")]
public class TagController(TagService service) : Controller
{
    [HttpGet]
    public async Task<ActionResult<List<Tag>>> GetAll(CancellationToken cancellationToken)
    {
        var tags = await service.GetAllAsync(cancellationToken);
        return Ok(tags);
    }

    [HttpGet("/{id:int}")]
    public async Task<ActionResult<Tag>> Get(int id, CancellationToken cancellationToken)
    {
        try
        {
            var tag = await service.GetByIdAsync(id, cancellationToken);
            return Ok(tag); 
        }
        catch (ArgumentException)
        {
            return NotFound($"Can not find a tag with Id = {id}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Tag>> Create([FromBody] TagDto tagDto, CancellationToken cancellationToken)
    {
        var tag = new Tag
        {
            Title = tagDto.Title
        };

        await service.CreateAsync(tag, cancellationToken);
        return Ok(tag);
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<Tag>> Update(int id, [FromBody] TagDto tagDto, CancellationToken cancellationToken)
    {
        var tag = new Tag
        {
            Title = tagDto.Title
        };

        await service.UpdateAsync(id, tag, cancellationToken);
        return Ok(tag);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Tag>> Delete(int id, CancellationToken cancellationToken)
    {
        try
        {
            var tag = await service.DeleteAsync(id, cancellationToken);
            return tag;
        }
        catch (ArgumentException)
        {
            return NotFound($"Can not find Tag with Id {id}");
        }
    }
}