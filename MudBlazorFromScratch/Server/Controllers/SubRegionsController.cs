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
    public class SubRegionsController : ControllerBase
    {
        private readonly MudBlazorDbContext _context;

        public SubRegionsController(MudBlazorDbContext context)
        {
            _context = context;
        }

        // GET: api/SubRegions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubRegion>>> GetSubRegion()
        {
            return await _context.SubRegion.ToListAsync();
        }

        // GET: api/SubRegions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubRegion>> GetSubRegion(int id)
        {
            var subRegion = await _context.SubRegion.FindAsync(id);

            if (subRegion == null)
            {
                return NotFound();
            }

            return subRegion;
        }

        // PUT: api/SubRegions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubRegion(int id, SubRegion subRegion)
        {
            if (id != subRegion.SubRegionId)
            {
                return BadRequest();
            }

            _context.Entry(subRegion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubRegionExists(id))
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

        // POST: api/SubRegions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubRegion>> PostSubRegion(SubRegion subRegion)
        {
            _context.SubRegion.Add(subRegion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubRegion", new { id = subRegion.SubRegionId }, subRegion);
        }

        // DELETE: api/SubRegions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubRegion(int id)
        {
            var subRegion = await _context.SubRegion.FindAsync(id);
            if (subRegion == null)
            {
                return NotFound();
            }

            _context.SubRegion.Remove(subRegion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubRegionExists(int id)
        {
            return _context.SubRegion.Any(e => e.SubRegionId == id);
        }
    }
}
