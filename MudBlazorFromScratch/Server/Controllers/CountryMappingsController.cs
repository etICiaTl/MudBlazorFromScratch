using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MudBlazorFromScratch.Server.Models;
using MudBlazorFromScratch.Shared;

namespace MudBlazorFromScratch.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryMappingsController : ControllerBase
    {
        private readonly MudBlazorDbContext _context;

        public CountryMappingsController(MudBlazorDbContext context)
        {
            _context = context;
        }

        // GET: api/CountryMappings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryMapping>>> GetCountryMapping()
        {
            return await _context.CountryMapping.ToListAsync();
        }

        // GET: api/CountryMappings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryMapping>> GetCountryMapping(int id)
        {
            var CountryMapping = await _context.CountryMapping.FindAsync(id);

            if (CountryMapping == null)
            {
                return NotFound();
            }

            return CountryMapping;
        }

        // PUT: api/CountryMappings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountryMapping(int id, CountryMapping CountryMapping)
        {
            if (id != CountryMapping.CountryMappingId)
            {
                return BadRequest();
            }

            _context.Entry(CountryMapping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryMappingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CountryMappings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CountryMapping>> PostCountryMapping(CountryMapping CountryMapping)
        {
            _context.CountryMapping.Add(CountryMapping);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountryMapping", new { id = CountryMapping.CountryMappingId }, CountryMapping);
        }

        // DELETE: api/CountryMappings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountryMapping(int id)
        {
            var CountryMapping = await _context.CountryMapping.FindAsync(id);
            if (CountryMapping == null)
            {
                return NotFound();
            }

            _context.CountryMapping.Remove(CountryMapping);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryMappingExists(int id)
        {
            return _context.CountryMapping.Any(e => e.CountryMappingId == id);
        }
    }
}
