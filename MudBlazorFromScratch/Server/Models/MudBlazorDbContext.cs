using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MudBlazorFromScratch.Shared;

namespace MudBlazorFromScratch.Server.Models
{
    public class MudBlazorDbContext : DbContext
    {
        public MudBlazorDbContext(DbContextOptions<MudBlazorDbContext> options) : base(options)
        {

        }

        public DbSet<Location> Location { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<SubRegion> SubRegion { get; set; }
        public DbSet<MudBlazorFromScratch.Shared.Audit> Audit { get; set; }
        public DbSet<MudBlazorFromScratch.Shared.AuditCountryPlatform> AuditCountryPlatform { get; set; }
        public DbSet<MudBlazorFromScratch.Shared.AuditFinding> AuditFinding { get; set; }
        public DbSet<CommercialUnit> CommercialUnit { get; set; }
        public DbSet<CountryMapping> CountryMapping { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<CountryToAudit> CountryToAudit { get; set; }
        public DbSet<PersonMapping> PersonMapping { get; set; }
    }
}
