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
    public class CountryToAuditsController : ControllerBase
    {
        private readonly MudBlazorDbContext _context;

        public CountryToAuditsController(MudBlazorDbContext context)
        {
            _context = context;
        }

        // GET: api/CountryToAudits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryToAudit>>> GetCountryToAudit()
        {
            return await _context.CountryToAudit.ToListAsync();
        }

        // GET: api/CountryToAudits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryToAudit>> GetCountryToAudit(int id)
        {
            var CountryToAudit = await _context.CountryToAudit.FindAsync(id);

            if (CountryToAudit == null)
            {
                return NotFound();
            }

            return CountryToAudit;
        }

        // PUT: api/CountryToAudits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountryToAudit(int id, CountryToAudit CountryToAudit)
        {
            if (id != CountryToAudit.CountryToAuditId)
            {
                return BadRequest();
            }

            _context.Entry(CountryToAudit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryToAuditExists(id))
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

        // POST: api/CountryToAudits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CountryToAudit>> PostCountryToAudit(CountryToAudit CountryToAudit)
        {
            _context.CountryToAudit.Add(CountryToAudit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountryToAudit", new { id = CountryToAudit.CountryToAuditId }, CountryToAudit);
        }

        // DELETE: api/CountryToAudits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountryToAudit(int id)
        {
            var CountryToAudit = await _context.CountryToAudit.FindAsync(id);
            if (CountryToAudit == null)
            {
                return NotFound();
            }

            _context.CountryToAudit.Remove(CountryToAudit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryToAuditExists(int id)
        {
            return _context.CountryToAudit.Any(e => e.CountryToAuditId == id);
        }
    }
}
