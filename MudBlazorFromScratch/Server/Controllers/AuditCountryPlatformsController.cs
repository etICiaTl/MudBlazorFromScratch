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
    public class AuditCountryPlatformsController : ControllerBase
    {
        private readonly MudBlazorDbContext _context;

        public AuditCountryPlatformsController(MudBlazorDbContext context)
        {
            _context = context;
        }

        // GET: api/AuditCountryPlatforms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditCountryPlatform>>> GetAuditCountryPlatform()
        {
            return await _context.AuditCountryPlatform.ToListAsync();
        }

        // GET: api/AuditCountryPlatforms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuditCountryPlatform>> GetAuditCountryPlatform(int id)
        {
            var auditCountryPlatform = await _context.AuditCountryPlatform.FindAsync(id);

            if (auditCountryPlatform == null)
            {
                return NotFound();
            }

            return auditCountryPlatform;
        }

        // PUT: api/AuditCountryPlatforms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuditCountryPlatform(int id, AuditCountryPlatform auditCountryPlatform)
        {
            if (id != auditCountryPlatform.AuditCountryPlatformId)
            {
                return BadRequest();
            }

            _context.Entry(auditCountryPlatform).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditCountryPlatformExists(id))
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

        // POST: api/AuditCountryPlatforms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AuditCountryPlatform>> PostAuditCountryPlatform(AuditCountryPlatform auditCountryPlatform)
        {
            _context.AuditCountryPlatform.Add(auditCountryPlatform);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuditCountryPlatform", new { id = auditCountryPlatform.AuditCountryPlatformId }, auditCountryPlatform);
        }

        // DELETE: api/AuditCountryPlatforms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuditCountryPlatform(int id)
        {
            var auditCountryPlatform = await _context.AuditCountryPlatform.FindAsync(id);
            if (auditCountryPlatform == null)
            {
                return NotFound();
            }

            _context.AuditCountryPlatform.Remove(auditCountryPlatform);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuditCountryPlatformExists(int id)
        {
            return _context.AuditCountryPlatform.Any(e => e.AuditCountryPlatformId == id);
        }
    }
}
