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
    public class AuditsController : ControllerBase
    {
        private readonly MudBlazorDbContext _context;

        public AuditsController(MudBlazorDbContext context)
        {
            _context = context;
        }

        // GET: api/Audits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Audit>>> GetAudit()
        {
            return await _context.Audit.ToListAsync();
        }

        // GET: api/Audits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Audit>> GetAudit(int id)
        {
            var audit = await _context.Audit.FindAsync(id);

            if (audit == null)
            {
                return NotFound();
            }

            return audit;
        }

        // PUT: api/Audits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAudit(int id, Audit audit)
        {
            if (id != audit.AuditId)
            {
                return BadRequest();
            }

            _context.Entry(audit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditExists(id))
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

        // POST: api/Audits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Audit>> PostAudit(Audit audit)
        {
            _context.Audit.Add(audit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAudit", new { id = audit.AuditId }, audit);
        }

        // DELETE: api/Audits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAudit(int id)
        {
            var audit = await _context.Audit.FindAsync(id);
            if (audit == null)
            {
                return NotFound();
            }

            _context.Audit.Remove(audit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuditExists(int id)
        {
            return _context.Audit.Any(e => e.AuditId == id);
        }
    }
}
