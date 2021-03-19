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

        // GET: api/Audits/Details
        [HttpGet("Details")]
        public async Task<ActionResult<IEnumerable<AuditDetail>>> GetAuditDetails()
        {
            IList<AuditDetail> auditDetails = new List<AuditDetail>();
            //IList<CountryToAudit> countryToAudits = new List<CountryToAudit>();
            //IList<PersonMapping> personMappings = new List<PersonMapping>();
            

            var audits = await _context.Audit.ToListAsync();

            foreach(var audit in audits)
            {
                var auditDetail = new AuditDetail
                {
                    AuditId = audit.AuditId,
                    Status = audit.Status,
                    Duration = audit.Duration,
                    Year = audit.Year,
                    AuditDate = audit.AuditDate
                };

                IList<CountryToAudit> countryToAudits = await _context.CountryToAudit.Where(x => x.AuditId == audit.AuditId).ToListAsync();
                IList<PersonMapping> personMappings = await _context.PersonMapping.Where(x => x.AuditId == audit.AuditId && x.IsPrimary == true).ToListAsync();
                
                IList<Country> countries = new List<Country>();
                IList<Person> people = new List<Person>();

                var countryNames = "";

                foreach (var countryToAudit in countryToAudits)
                {
                    var country = await _context.Country.Where(x => x.CountryId == countryToAudit.CountryId).FirstOrDefaultAsync();
                    countryNames = countryNames + country.CountryName + "; ";
                    countries.Add(country);
                }

                foreach (var personMapping in personMappings)
                {
                    var person = await _context.Person.Where(x => x.PersonId == personMapping.PersonId).FirstOrDefaultAsync();
                    people.Add(person);
                }

                auditDetail.CountryToAudits = countryToAudits;
                auditDetail.Countries = countries;
                auditDetail.CountryNames = countryNames;
                auditDetail.PersonMappings = personMappings;
                auditDetail.People = people;

                auditDetails.Add(auditDetail);
            }


            return auditDetails.ToList();
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
