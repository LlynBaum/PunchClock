using M223PunchclockDotnet.Model;
using Microsoft.AspNetCore.Mvc;

namespace M223PunchclockDotnet.Controllers;

[ApiController]
[Route("tag")]
public class TagController : Controller
{
    private readonly List<Tag> _tags =
    [
        new()
        {
            Id = 1,
            Title = "1"
        },
        new()
        {
            Id = 2,
            Title = "2"
        }
    ];
    
    [HttpGet]
    public ActionResult<List<Tag>> GetAll()
    {
        return Ok(_tags);
    }

    [HttpGet("/{id:int}")]
    public ActionResult<Tag> Get(int id)
    {
        var tag = _tags.SingleOrDefault(t => t.Id == id);
        return tag is not null ? Ok(tag) : NotFound($"Can not find a tag with Id = {id}");
    }
    
    
}