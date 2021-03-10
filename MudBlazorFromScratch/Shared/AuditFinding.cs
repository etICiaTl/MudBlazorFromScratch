using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazorFromScratch.Shared
{
    public class AuditFinding
    {
        public int AuditFindingId { get; set; }
        public int AuditId { get; set; }
        public int AuditCountryPlatformId { get; set; }
        public string Finding { get; set; }
    }
}
