using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazorFromScratch.Shared
{
    public class AuditDetail    {
        public int AuditId { get; set; }
        public string Status { get; set; }
        public int Duration { get; set; }
        public int Year { get; set; }
        public DateTime AuditDate { get; set; }
        public IList<CountryToAudit> CountryToAudits { get; set; }
        public IList<Country> Countries { get; set; }
        public IList<PersonMapping> PersonMappings { get; set; }
        public IList<Person> People { get; set; }
        public string CountryNames { get; set; }
    }
}
