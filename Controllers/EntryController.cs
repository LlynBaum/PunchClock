using System.Net.Mime;
using M223PunchclockDotnet.Dto;
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
        public async Task<ActionResult<Entry>> AddEntry(EntryDto entryDto)
        {
            var entry = new Entry
            {
                CheckIn = entryDto.CheckIn,
                CheckOut = entryDto.CheckOut
            };
            
            var newEntry = await entryService.AddEntry(entry);
            return CreatedAtAction(nameof(Get), new{id = newEntry.Id}, newEntry);
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
        public async Task<ActionResult<Entry>> PutEntry(int id, [FromBody] EntryDto entryDto, CancellationToken cancellation)
        {
            try
            {
                var entry = new Entry
                {
                    CheckIn = entryDto.CheckIn,
                    CheckOut = entryDto.CheckOut
                };
                
                var updatedEntry = await entryService.UpdateAsync(id, entry, cancellation);
                return updatedEntry;
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
