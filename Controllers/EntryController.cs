using System.Net.Mime;
using M223PunchclockDotnet.Model;
using M223PunchclockDotnet.Service;
using Microsoft.AspNetCore.Mvc;

namespace M223PunchclockDotnet.Controllers
{
    [ApiController]
    [Route("entry")]
    public class EntryController(EntryService entryService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType<Entry>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var allEntries = await entryService.GetAll();
            return Ok(allEntries);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType<Entry>(StatusCodes.Status201Created)]
        public async Task<ActionResult<Entry>> AddEntry(Entry entry)
        {
            _ = await entryService.AddEntry(entry);
            return CreatedAtAction(nameof(Get), new{id = entry.Id}, entry);
        }

        [HttpDelete("{id:int}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType<Entry>(StatusCodes.Status200OK)]
        public async Task<ActionResult<Entry>> DeleteEntry(int id, CancellationToken cancellation)
        {
            try
            {
                var entry = await entryService.DeleteAsync(id, cancellation);
                return entry;
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType<Entry>(StatusCodes.Status200OK)]
        public async Task<ActionResult<Entry>> PutEntry(int id, [FromBody] Entry entry, CancellationToken cancellation)
        {
            try
            {
                var newEntry = await entryService.UpdateAsync(id, entry, cancellation);
                return newEntry;
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
