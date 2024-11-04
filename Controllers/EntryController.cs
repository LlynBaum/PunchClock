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
        public async Task<ActionResult<Entry>> AddEntry(Entry entry){
            _ = await entryService.AddEntry(entry);
            return CreatedAtAction(nameof(Get), new{id = entry.Id}, entry);
        }

        [HttpDelete("{id:int}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType<Entry>(StatusCodes.Status200OK)]
        public async Task<ActionResult<Entry>> DeleteEntry(int id, CancellationToken cancellation)
        {
            var entry = await entryService.DeleteAsync(id, cancellation);
            if (entry is null)
            {
                return NotFound($"Entry with Id = {id} not found");
            }

            return entry;
        }

        [HttpPatch("{id:int}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType<Entry>(StatusCodes.Status200OK)]
        public async Task<ActionResult<Entry>> PatchEntry(int id, [FromBody] Entry entry, CancellationToken cancellation)
        {
            var newEntry = await entryService.UpdateAsync(id, entry, cancellation);
            if (newEntry is null)
            {
                return NotFound($"Entry with Id = {id} not found");
            }

            return entry;
        }
    }
}
