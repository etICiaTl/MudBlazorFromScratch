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
    public class PersonMappingsController : ControllerBase
    {
        private readonly MudBlazorDbContext _context;

        public PersonMappingsController(MudBlazorDbContext context)
        {
            _context = context;
        }

        // GET: api/PersonMappings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonMapping>>> GetPersonMapping()
        {
            return await _context.PersonMapping.ToListAsync();
        }

        // GET: api/PersonMappings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonMapping>> GetPersonMapping(int id)
        {
            var PersonMapping = await _context.PersonMapping.FindAsync(id);

            if (PersonMapping == null)
            {
                return NotFound();
            }

            return PersonMapping;
        }

        // PUT: api/PersonMappings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonMapping(int id, PersonMapping PersonMapping)
        {
            if (id != PersonMapping.PersonMappingId)
            {
                return BadRequest();
            }

            _context.Entry(PersonMapping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonMappingExists(id))
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

        // POST: api/PersonMappings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonMapping>> PostPersonMapping(PersonMapping PersonMapping)
        {
            _context.PersonMapping.Add(PersonMapping);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonMapping", new { id = PersonMapping.PersonMappingId }, PersonMapping);
        }

        // DELETE: api/PersonMappings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonMapping(int id)
        {
            var PersonMapping = await _context.PersonMapping.FindAsync(id);
            if (PersonMapping == null)
            {
                return NotFound();
            }

            _context.PersonMapping.Remove(PersonMapping);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonMappingExists(int id)
        {
            return _context.PersonMapping.Any(e => e.PersonMappingId == id);
        }
    }
}
