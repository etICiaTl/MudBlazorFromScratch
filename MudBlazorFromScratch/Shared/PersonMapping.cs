using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazorFromScratch.Shared
{
    public class PersonMapping
    {
        public int PersonMappingId { get; set; }
        public int AuditId { get; set; }
        public int PersonId { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsAuditor { get; set; }
        public bool IsContact { get; set; }
    }
}
