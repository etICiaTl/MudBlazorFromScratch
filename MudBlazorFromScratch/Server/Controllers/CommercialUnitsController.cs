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
    public class CommercialUnitsController : ControllerBase
    {
        private readonly MudBlazorDbContext _context;

        public CommercialUnitsController(MudBlazorDbContext context)
        {
            _context = context;
        }

        // GET: api/CommercialUnit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommercialUnit>>> GetCommercialUnit()
        {
            return await _context.CommercialUnit.ToListAsync();
        }

        // GET: api/CommercialUnit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommercialUnit>> GetCommercialUnit(int id)
        {
            var CommercialUnit = await _context.CommercialUnit.FindAsync(id);

            if (CommercialUnit == null)
            {
                return NotFound();
            }

            return CommercialUnit;
        }

        // PUT: api/CommercialUnit/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommercialUnit(int id, CommercialUnit CommercialUnit)
        {
            if (id != CommercialUnit.CommercialUnitId)
            {
                return BadRequest();
            }

            _context.Entry(CommercialUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommercialUnitExists(id))
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

        // POST: api/CommercialUnit
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommercialUnit>> PostCommercialUnit(CommercialUnit CommercialUnit)
        {
            _context.CommercialUnit.Add(CommercialUnit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommercialUnit", new { id = CommercialUnit.CommercialUnitId }, CommercialUnit);
        }

        // DELETE: api/CommercialUnit/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommercialUnit(int id)
        {
            var CommercialUnit = await _context.CommercialUnit.FindAsync(id);
            if (CommercialUnit == null)
            {
                return NotFound();
            }

            _context.CommercialUnit.Remove(CommercialUnit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommercialUnitExists(int id)
        {
            return _context.CommercialUnit.Any(e => e.CommercialUnitId == id);
        }
    }
}
