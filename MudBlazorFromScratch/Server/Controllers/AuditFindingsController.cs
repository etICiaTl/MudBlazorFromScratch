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
    public class AuditFindingsController : ControllerBase
    {
        private readonly MudBlazorDbContext _context;

        public AuditFindingsController(MudBlazorDbContext context)
        {
            _context = context;
        }

        // GET: api/AuditFindings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditFinding>>> GetAuditFinding()
        {
            return await _context.AuditFinding.ToListAsync();
        }

        // GET: api/AuditFindings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuditFinding>> GetAuditFinding(int id)
        {
            var auditFinding = await _context.AuditFinding.FindAsync(id);

            if (auditFinding == null)
            {
                return NotFound();
            }

            return auditFinding;
        }

        // PUT: api/AuditFindings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuditFinding(int id, AuditFinding auditFinding)
        {
            if (id != auditFinding.AuditFindingId)
            {
                return BadRequest();
            }

            _context.Entry(auditFinding).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditFindingExists(id))
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

        // POST: api/AuditFindings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AuditFinding>> PostAuditFinding(AuditFinding auditFinding)
        {
            _context.AuditFinding.Add(auditFinding);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuditFinding", new { id = auditFinding.AuditFindingId }, auditFinding);
        }

        // DELETE: api/AuditFindings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuditFinding(int id)
        {
            var auditFinding = await _context.AuditFinding.FindAsync(id);
            if (auditFinding == null)
            {
                return NotFound();
            }

            _context.AuditFinding.Remove(auditFinding);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuditFindingExists(int id)
        {
            return _context.AuditFinding.Any(e => e.AuditFindingId == id);
        }
    }
}
