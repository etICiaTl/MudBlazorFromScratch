﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazorFromScratch.Shared
{
    public class Audit
    {
        public int AuditId { get; set; }
        public string Status { get; set; }
        public int Duration { get; set; }
        public int Year { get; set; }
        public DateTime AuditDate { get; set; }
    }
}
