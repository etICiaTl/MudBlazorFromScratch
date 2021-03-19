using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazorFromScratch.Shared
{
    public class CountryToAudit
    {
        public int CountryToAuditId { get; set; }
        public int AuditId { get; set; }
        public int CountryId { get; set; }
        public bool IsConventionalSeeds { get; set; }
        public bool IsCropProtection { get; set; }
        public bool IsTraitedSeeds { get; set; }
    }
}
